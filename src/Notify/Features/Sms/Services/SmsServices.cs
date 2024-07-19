namespace Notify.Features.Sms.Services
{
    public class SmsServices(SmsDbContext dbContext,IServiceProvider serviceProvider)
    {
        private readonly SmsDbContext _dbContext = dbContext;
        private readonly IServiceProvider _serviceProvider =serviceProvider;

        public async Task SendAsync(Guid messageId,string mobile , string message , CancellationToken cancellationToken)
        {
            foreach (var providerName in SmsConfiguration.Providers)
            {
                var provider = _serviceProvider.GetRequiredKeyedService<ISmsProvider>(providerName);

                var referenceId = await provider.SendAsync(mobile, message, cancellationToken);
                if (string.IsNullOrEmpty(referenceId))
                {
                    //try by sending with another provider
                    continue;
                }
                var smsTrace = SmsTrace.Create(mobile, message, messageId,referenceId,provider.Name);
                await _dbContext.SmsTraces.AddAsync(smsTrace);
                await _dbContext.SaveChangesAsync(cancellationToken);

                // end of try
                break;
            }
        }

        public async Task<SmsTraceStatus> InquiryAsync(SmsTrace message,CancellationToken cancellationToken)
        {
            var provider = _serviceProvider.GetRequiredKeyedService<ISmsProvider>(message.Provider);
            return await provider.InquiryAsync(message.RefrenceId, cancellationToken);
        }
    }
}
