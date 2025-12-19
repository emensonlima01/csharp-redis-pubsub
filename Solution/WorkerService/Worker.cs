using Application.Events;
using Application.Messaging;

namespace WorkerService;

public class Worker(
    IMessageBusService messageBusService,
    IEventHandler<PaymentReceivedEvent> eventHandler) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await messageBusService.SubscribeAsync(
            PaymentChannels.PaymentReceived,
            eventHandler
        );

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }
}
