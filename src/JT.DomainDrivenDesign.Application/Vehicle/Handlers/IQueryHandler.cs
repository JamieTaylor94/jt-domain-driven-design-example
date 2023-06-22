namespace JT.DomainDrivenDesign.Application.Vehicle.Handlers;

public interface IQueryHandler<TInput, TOutput>
{
    Task<TOutput> Handle(TInput message);
}