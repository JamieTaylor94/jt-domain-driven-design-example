namespace JT.DomainDrivenDesign.Application.Vehicle.Handlers;

public interface ICommandHandler<TMessage>
{
    Task Handle(TMessage message);
}