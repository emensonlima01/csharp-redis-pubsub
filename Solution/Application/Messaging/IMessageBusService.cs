namespace Application.Messaging;

public interface IMessageBusService
{
    Task PublishAsync<T>(string channel, T message) where T : class;
    Task SubscribeAsync<T>(string channel, IEventHandler<T> eventHandler) where T : class;
}
