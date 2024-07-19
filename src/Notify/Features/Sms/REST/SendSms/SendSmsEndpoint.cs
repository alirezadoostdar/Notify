
namespace Notify.Features.Sms.REST.SendSms
{
    public class SendSmsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/sms", async (SendSmsRequest request, IMediator mediator) =>
            {
                var notify = new SendSmsMessage(request.MessageId, request.Mobile, request.Message);
                await mediator.Publish(notify);
            }).WithTags("Sms");
        }
    }
}
