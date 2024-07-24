using IPE.SmsIrClient;

namespace Notify.Features.Sms.Providers
{
    public class SmsIrProvider(IConfiguration configuration) : ISmsProvider
    {
        
        public string Name => throw new NotImplementedException();

        public Task<SmsTraceStatus> InquiryAsync(string referenceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SendAsync(string mobile, string message, CancellationToken cancellationToken)
        {
            var setting = configuration.Get<AppSettings>();
            if (setting is null)
            {
                throw new ArgumentNullException();
            }
            SmsIr smsIr = new SmsIr(setting.Features.Sms.SmsIr.apiKey);
            //smsIr.VerifySendAsync
            string[] number = [mobile];
            var res = await smsIr.BulkSendAsync(setting.Features.Sms.SmsIr.lineNumber, message,number );
            return res.ToString();
        }

    }
}
