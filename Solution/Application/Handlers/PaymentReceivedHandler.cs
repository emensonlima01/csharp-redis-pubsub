using Application.Events;
using Application.Messaging;
using Application.UseCases;

namespace Application.Handlers;

public class PaymentReceivedHandler(ProcessPaymentUseCase useCase) : IEventHandler<PaymentReceivedEvent>
{
    public async Task Handle(PaymentReceivedEvent message)
    {
        await useCase.Handle(message);
    }
}
