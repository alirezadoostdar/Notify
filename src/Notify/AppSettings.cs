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

    }

    public class BrokerConfiguration
    {

    }
    public partial class FeatureConfiguration
    {

    }
}
