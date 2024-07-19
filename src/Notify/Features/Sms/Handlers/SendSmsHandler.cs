using Notify.Features.Sms.Services;

namespace Notify.Features.Sms.Handlers
{
    public class SendSmsHandler(SmsServices smsServices) : INotificationHandler<SendSmsMessage>
    {
        private readonly SmsServices _smsService = smsServices;
        public async Task Handle(SendSmsMessage notification, CancellationToken cancellationToken)
        {
            await _smsService.SendAsync(notification.MessageId,
                notification.Mobile,
                notification.Message, cancellationToken);
        }
    }
}
