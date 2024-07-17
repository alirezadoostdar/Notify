namespace Notify.Features.Sms
{
    public interface ISmsProvider
    {
        Task<string> SendAsync(string mobile,string message,CancellationToken cancellationToken);
        Task<SmsTraceStatus> InquiryAsync(string referenceId,CancellationToken cancellationToken);
        string Name { get; }
    }
}
