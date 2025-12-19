namespace Application.Messaging;

public interface IEventHandler<in T>
{
    Task Handle(T message);
}
