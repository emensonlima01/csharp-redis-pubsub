using Application.DTOs;
using Application.Events;
using Application.Messaging;

namespace Application.UseCases;

public class ReceivePaymentUseCase(IMessageBusService messageBusService)
{
    public async Task Handle(ReceivePaymentRequest request)
    {
        var paymentEvent = new PaymentReceivedEvent
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow
        };

        await messageBusService.PublishAsync(PaymentChannels.PaymentReceived, paymentEvent);
    }
}
