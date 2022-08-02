using FindMyDevice.Models;
using System.Text.Json;
using System.Text;

namespace FindMyDevice;

public class ICloudConnect
{
    string _iCloudBaseUrl;
    HttpClient _httpClient;
    const string ICLOUD_URL = "https://www.icloud.com";
    const string ICLOUD_LOGIN_URL = "https://setup.icloud.com/setup/ws/1/login";
    const string ICLOUD_INIT_CLIENT_URL = "/fmipservice/client/web/initClient";
    const string ICLOUD_PLAY_SOUND_URL = "/fmipservice/client/web/playSound";
    const string ICLOUD_LOST_MODE = "/fmipservice/client/web/lostDevice";

    public ICloudConnect(string appleId, string password)
    {
        Authenticate(appleId, password).Wait();
    }

    async Task Authenticate(string appleId, string password)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Origin", ICLOUD_URL);
        _httpClient.DefaultRequestHeaders.Add("Content-Type", "text/plain");

        var loginParams = new LoginParameters
        {
            apple_id = appleId,
            password = password,
            extended_login = false
        };

        try
        {
            var httpResponse = await _httpClient.Post(ICLOUD_LOGIN_URL, loginParams.ToJson());

            if (httpResponse.Content.Headers.Contains("Set-Cookie"))
            {
                _httpClient.DefaultRequestHeaders.Add("Cookie", httpResponse.Content.Headers.GetValues("Set-Cookie").First());

                var response = await httpResponse.Content.ReadAsStringAsync();
                var obj = response.ToObject<LoginResponse>();
                _iCloudBaseUrl = obj?.webservices.findme.url ?? string.Empty;
            }
            else
                throw new System.Security.SecurityException("Invalid username or password.");
        }
        catch (System.Net.WebException)
        {
            throw new System.Security.SecurityException("Invalid username or password.");
        }
    }

    async Task<string> GetUserInfo()
    {
        var userInfoParams = new UserInfoParameters
        {
            clientContext = new ClientContext
            {
                appName = "iCloud Find (Web)",
                appVersion = "2.0",
                timezone = "US/Eastern", //TODO: set up timezones
                inactiveTime = 2255,
                apiVersion = "3.0",
                webStats = "0:15"
            }
        };

        var httpResponse = await _httpClient.Post(string.Concat(_iCloudBaseUrl, ICLOUD_INIT_CLIENT_URL), userInfoParams.ToJson());

        if (httpResponse.IsSuccessStatusCode)
            return await httpResponse.Content.ReadAsStringAsync();
        else
            throw new Exception($"Could not get User Info. Response from initClient: {httpResponse.StatusCode} - {httpResponse.Content.ReadAsStringAsync().Result}");
    }

    public async Task<List<Device>> GetDevices()
    {
        var response = await GetUserInfo();
        var userInfo = response.ToObject<UserInfoRespose>();
        return userInfo?.content ?? new List<Device>();
    }

    public async Task<Device> GetDevice(string deviceId)
    {
        var devices = await GetDevices();

        return devices.FirstOrDefault(x => x.Id == deviceId) ?? new Device();
    }

    public async Task PlaySound(string deviceId, string message)
    {
        var device = this.GetDevice(deviceId);
        if (device is null)
            throw new ArgumentException($"Device \"{deviceId}\" was not found.");

        var playSoundParams = new PlaySoundParameters { device = deviceId, subject = message };

        await _httpClient.Post(_iCloudBaseUrl + ICLOUD_PLAY_SOUND_URL, playSoundParams.ToJson());
    }

    public async Task EnableLostMode(string deviceId, string message, string contactNumber)
    {
        var lostModeParams = new LostModeParameters
        {
            device = deviceId,
            lostModeEnabled = true,
            trackingEnabled = true,
            userText = true,
            ownerNbr = contactNumber,
            text = message
        };

        await _httpClient.Post(string.Concat(_iCloudBaseUrl, ICLOUD_LOST_MODE), lostModeParams.ToJson());
    }

    //TODO: Implement Wipe mode
    //TODO: Implement robots.txt check
}

public static class Extensions
{
    public static string ToJson(this object obj) => JsonSerializer.Serialize(obj);

    public static T ToObject<T>(this string text) => JsonSerializer.Deserialize<T>(text);

    public static async Task<HttpResponseMessage> Post(this HttpClient client, string url, string postData)
    {
        var content = new StringContent(postData, Encoding.UTF8,"application/json");
        return await client.PostAsync(url, content);
    }
}