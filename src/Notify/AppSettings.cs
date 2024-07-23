namespace Notify
{
    public class AppSettings
    {
        public SvcDbContextConfiguration SvcDbContext { get; set; } = null;
        public BrokerConfiguration BrokerConfiguration { get; set; } = null;
        public FeatureConfiguration Features { get; set; } = null;
        public string BaseUrl { get; set; } = null;
    }

    public class SvcDbContextConfiguration
    {
        public required string Host { get; set; }
        public required string DatabaseName {  get; set; }
    }

    public class BrokerConfiguration
    {
        public required string Host { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
    public partial class FeatureConfiguration
    {

    }
}
