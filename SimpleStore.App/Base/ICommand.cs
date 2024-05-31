using MediatR;

namespace SimpleStore.App.Base;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}
