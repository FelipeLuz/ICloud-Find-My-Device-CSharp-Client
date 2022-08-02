namespace FindMyDevice.Models;

public class Device
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DeviceDisplayName { get; set; }
    public string ModelDisplayName { get; set; }
    public string RawDeviceModel { get; set; }
    public string DeviceModel { get; set; }
    public string DeviceClass { get; set; }
    public string DeviceStatus { get; set; }
    public decimal BatteryLevel { get; set; }
    public string BatteryStatus { get; set; }
    public bool CanWipeAfterLock { get; set; }
    public bool WipeInProgress { get; set; }
    public bool LostModeEnabled { get; set; }
    public bool ActivationLocked { get; set; }
    public bool LowPowerMode { get; set; }
    public bool IsLocating { get; set; }
    public bool LocationEnabled { get; set; }
    public bool LocFoundEnabled { get; set; }
    public bool FmlyShare { get; set; }
    public bool LostModeCapable { get; set; }
    public bool LocationCapable { get; set; }
    public LostDevice LostDevice { get; set; }
    public string LostTimestamp { get; set; }
    public string LockedTimestamp { get; set; }
    public string WipedTimestamp { get; set; }
    public Location Location { get; set; }
}

public class LoginParameters
{
    public string apple_id { get; set; }
    public string password { get; set; }
    public bool extended_login { get; set; }
}

public class ClientContext
{
    public string appName { get; set; }
    public string appVersion { get; set; }
    public string timezone { get; set; }
    public int inactiveTime { get; set; }
    public string apiVersion { get; set; }
    public string webStats { get; set; }
}

public class UserInfoParameters
{
    public ClientContext clientContext { get; set; }
}

public class PlaySoundParameters
{
    public string device { get; set; }
    public string subject { get; set; }
}

public class LostModeParameters
{
    public string device { get; set; }
    public bool lostModeEnabled { get; set; }
    public bool trackingEnabled { get; set; }
    public bool userText { get; set; }
    public string ownerNbr { get; set; }
    public string text { get; set; }
}

public class Location
{
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public decimal HorizontalAccuracy { get; set; }
    public string PositionType { get; set; }
    public string LocationType { get; set; }
    public long Timestamp { get; set; }
    public bool IsOld { get; set; }
    public bool IsInaccurate { get; set; }
    public bool LocationFinished { get; set; }
}

public class LostDevice
{
    public bool stopLostMode { get; set; }
    public bool emailUpdates { get; set; }
    public bool userText { get; set; }
    public bool sound { get; set; }
    public string ownerNbr { get; set; }
    public string text { get; set; }
    public string email { get; set; }
    public long createTimestamp { get; set; }
    public string statusCode { get; set; }
}

public class AppleIdEntry
{
    public bool isPrimary { get; set; }
    public string type { get; set; }
    public string value { get; set; }
}

public class Apps
{
    public Find find { get; set; }
}

public class ConfigBag
{
    public Urls urls { get; set; }
    public bool accountCreateEnabled { get; set; }
}

public class DsInfo
{
    public string lastName { get; set; }
    public bool iCDPEnabled { get; set; }
    public bool tantorMigrated { get; set; }
    public string dsid { get; set; }
    public bool hsaEnabled { get; set; }
    public bool isHideMyEmailSubscriptionActive { get; set; }
    public bool ironcadeMigrated { get; set; }
    public string locale { get; set; }
    public bool brZoneConsolidated { get; set; }
    public bool isManagedAppleID { get; set; }
    public bool isCustomDomainsFeatureAvailable { get; set; }
    public bool isHideMyEmailFeatureAvailable { get; set; }
    public List<object> appleIdAliases { get; set; }
    public int hsaVersion { get; set; }
    public bool ubiquityEOLEnabled { get; set; }
    public bool isPaidDeveloper { get; set; }
    public string countryCode { get; set; }
    public string notificationId { get; set; }
    public bool primaryEmailVerified { get; set; }
    public string aDsID { get; set; }
    public bool locked { get; set; }
    public bool hasICloudQualifyingDevice { get; set; }
    public string primaryEmail { get; set; }
    public List<AppleIdEntry> appleIdEntries { get; set; }
    public string fullName { get; set; }
    public MailFlags mailFlags { get; set; }
    public string languageCode { get; set; }
    public string appleId { get; set; }
    public bool analyticsOptInStatus { get; set; }
    public string firstName { get; set; }
    public string iCloudAppleIdAlias { get; set; }
    public bool notesMigrated { get; set; }
    public bool hasPaymentInfo { get; set; }
    public bool pcsDeleted { get; set; }
    public bool isCustomDomainTransferSubscriptionActive { get; set; }
    public string appleIdAlias { get; set; }
    public bool brMigrated { get; set; }
    public int statusCode { get; set; }
    public bool familyEligible { get; set; }
}

public class Find
{
    public bool canLaunchWithOneFactor { get; set; }
}

public class Findme
{
    public string url { get; set; }
    public string status { get; set; }
}

public class ICloudInfo
{
    public bool SafariBookmarksHasMigratedToCloudKit { get; set; }
}

public class MailFlags
{
    public bool isThreadingAvailable { get; set; }
    public bool isSearchV2Provisioned { get; set; }
    public bool isCKMail { get; set; }
}

public class RequestInfo
{
    public string country { get; set; }
    public string timeZone { get; set; }
    public string region { get; set; }
}

public class LoginResponse
{
    public DsInfo dsInfo { get; set; }
    public bool hasMinimumDeviceForPhotosWeb { get; set; }
    public bool iCDPEnabled { get; set; }
    public Webservices webservices { get; set; }
    public bool pcsEnabled { get; set; }
    public ConfigBag configBag { get; set; }
    public bool hsaTrustedBrowser { get; set; }
    public List<string> appsOrder { get; set; }
    public int version { get; set; }
    public bool isExtendedLogin { get; set; }
    public bool pcsServiceIdentitiesIncluded { get; set; }
    public bool hsaChallengeRequired { get; set; }
    public RequestInfo requestInfo { get; set; }
    public bool pcsDeleted { get; set; }
    public ICloudInfo iCloudInfo { get; set; }
    public Apps apps { get; set; }
}

public class Urls
{
    public string accountCreateUI { get; set; }
    public string accountLoginUI { get; set; }
    public string accountLogin { get; set; }
    public string accountRepairUI { get; set; }
    public string downloadICloudTerms { get; set; }
    public string repairDone { get; set; }
    public string accountAuthorizeUI { get; set; }
    public string vettingUrlForEmail { get; set; }
    public string accountCreate { get; set; }
    public string getICloudTerms { get; set; }
    public string vettingUrlForPhone { get; set; }
}

public class Webservices
{
    public Findme findme { get; set; }
}

public class AudioChannel
{
    public string name { get; set; }
    public int available { get; set; }
    public bool playing { get; set; }
    public bool muted { get; set; }
}

public class Content
{
    public Msg msg { get; set; }
    public bool activationLocked { get; set; }
    public int passcodeLength { get; set; }
    public bool scd { get; set; }
    public string id { get; set; }
    public object remoteLock { get; set; }
    public int rm2State { get; set; }
    public string modelDisplayName { get; set; }
    public bool fmlyShare { get; set; }
    public bool lostModeCapable { get; set; }
    public object wipedTimestamp { get; set; }
    public object encodedDeviceId { get; set; }
    public string scdPh { get; set; }
    public bool locationCapable { get; set; }
    public object trackingInfo { get; set; }
    public string name { get; set; }
    public bool isMac { get; set; }
    public bool thisDevice { get; set; }
    public string deviceClass { get; set; }
    public bool nwd { get; set; }
    public object remoteWipe { get; set; }
    public bool canWipeAfterLock { get; set; }
    public string baUUID { get; set; }
    public bool lostModeEnabled { get; set; }
    public bool wipeInProgress { get; set; }
    public string deviceStatus { get; set; }
    public string deviceColor { get; set; }
    public bool isConsideredAccessory { get; set; }
    public bool deviceWithYou { get; set; }
    public bool lowPowerMode { get; set; }
    public string rawDeviceModel { get; set; }
    public string deviceDiscoveryId { get; set; }
    public bool isLocating { get; set; }
    public string lostTimestamp { get; set; }
    public object mesg { get; set; }
    public double? batteryLevel { get; set; }
    public bool locationEnabled { get; set; }
    public object lockedTimestamp { get; set; }
    public bool locFoundEnabled { get; set; }
    public object lostDevice { get; set; }
    public string deviceDisplayName { get; set; }
    public object prsId { get; set; }
    public List<AudioChannel> audioChannels { get; set; }
    public string batteryStatus { get; set; }
    public Location location { get; set; }
    public string deviceModel { get; set; }
    public int maxMsgChar { get; set; }
    public bool darkWake { get; set; }
}

public class Msg
{
    public bool strobe { get; set; }
    public bool userText { get; set; }
    public bool playSound { get; set; }
    public bool vibrate { get; set; }
    public long createTimestamp { get; set; }
    public string statusCode { get; set; }
}

public class UserInfoRespose
{
    public UserInfo userInfo { get; set; }
    public object alert { get; set; }
    public ServerContext serverContext { get; set; }
    public object userPreferences { get; set; }
    public List<Device> content { get; set; }
    public string statusCode { get; set; }
}

public class ServerContext
{
    public int minCallbackIntervalInMS { get; set; }
    public string preferredLanguage { get; set; }
    public bool enable2FAFamilyActions { get; set; }
    public object lastSessionExtensionTime { get; set; }
    public bool validRegion { get; set; }
    public int callbackIntervalInMS { get; set; }
    public bool enableMapStats { get; set; }
    public Timezone timezone { get; set; }
    public object authToken { get; set; }
    public int maxCallbackIntervalInMS { get; set; }
    public bool classicUser { get; set; }
    public bool isHSA { get; set; }
    public int trackInfoCacheDurationInSecs { get; set; }
    public string imageBaseUrl { get; set; }
    public int minTrackLocThresholdInMts { get; set; }
    public string itemLearnMoreURL { get; set; }
    public int maxLocatingTime { get; set; }
    public bool itemsTabEnabled { get; set; }
    public int sessionLifespan { get; set; }
    public string info { get; set; }
    public int prefsUpdateTime { get; set; }
    public bool useAuthWidget { get; set; }
    public string clientId { get; set; }
    public int inaccuracyRadiusThreshold { get; set; }
    public long serverTimestamp { get; set; }
    public bool enable2FAFamilyRemove { get; set; }
    public string deviceImageVersion { get; set; }
    public int macCount { get; set; }
    public string deviceLoadStatus { get; set; }
    public int maxDeviceLoadTime { get; set; }
    public long prsId { get; set; }
    public bool showSllNow { get; set; }
    public bool cloudUser { get; set; }
    public bool enable2FAErase { get; set; }
}

public class Timezone
{
    public int currentOffset { get; set; }
    public long previousTransition { get; set; }
    public int previousOffset { get; set; }
    public string tzCurrentName { get; set; }
    public string tzName { get; set; }
}

public class UserInfo
{
    public int accountFormatter { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public object membersInfo { get; set; }
    public bool hasMembers { get; set; }
}
