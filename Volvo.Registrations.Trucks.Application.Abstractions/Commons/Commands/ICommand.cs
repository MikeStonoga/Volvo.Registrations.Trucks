namespace Volvo.Registrations.Trucks.Application.Abstractions.Commons.Commands;

public interface ICommand<TRequirement, TResult>
{
    Task<TResult> Execute(TRequirement requirement);
}
