namespace Notify.Features.Sms
{
    public partial class SmsFeatureSettings
    {
    }
}

public class SmsConfiguration
{
    public SmsIrConfiguration SmsIr { get; set; }
    public KavehnegarConfiguration Kavehnegar { get; set; }
    public readonly static IList<string> Providers = ["SmsIr", "Kavehnegar"];
}

public class SmsIrConfiguration
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Number { get; set; }
}

public class KavehnegarConfiguration
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Number { get; set; }
}

