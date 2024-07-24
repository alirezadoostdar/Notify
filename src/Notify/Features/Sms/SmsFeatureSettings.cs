namespace Notify
{
    public partial class FeatureConfiguration
    {
        public SmsConfiguration Sms { get; set; } = null!;
    }

    public class SmsConfiguration
    {
        public SmsIrConfiguration SmsIr { get; set; }
        public KavehnegarConfiguration Kavehnegar { get; set; }
        public readonly static IList<string> Providers = ["SmsIrProvider", "KavehnegarProvider"];
    }

    public class SmsIrConfiguration
    {
        public required string apiKey { get; set; }
        public required string secretKey { get; set; }
        public required long lineNumber { get; set; }
    }

    public class KavehnegarConfiguration
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Number { get; set; }
    }
}



