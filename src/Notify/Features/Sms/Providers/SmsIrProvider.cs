
namespace Notify.Features.Sms.Providers
{
    public class SmsIrProvider : ISmsProvider
    {
        public string Name => throw new NotImplementedException();

        public Task<SmsTraceStatus> InquiryAsync(string referenceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> SendAsync(string mobile, string message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
