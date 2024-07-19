using Notify.Features.Sms.Services;

namespace Notify.Features.Sms
{
    public static class SmsFeatureConfigure
    {
        public static IServiceCollection ConfigureSmsFeature(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddHostedService<InquirySmsBackgroundService>();
            services.AddScoped<SmsServices>();

            services.AddKeyedScoped<ISmsProvider, SmsIrProvider>("SmsIrProvider");
            services.AddKeyedScoped<ISmsProvider, KavehNegarProvider>("KavehNegarProvider");

            var appSetting = configuration.Get<AppSetting>();

            services.AddDbContext<SmsDbContext>(options =>
            {
                if (appSetting! is null)
                {
                    throw new ArgumentNullException(nameof(appSetting));
                }

                var svcDbContext = appSetting.SvcDbContext;
                options.UseMongoDB(svcDbContext.Host, svcDbContext.DatabaseName);
            });

            return services;
        }
    }
}
