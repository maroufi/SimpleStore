using MediatR;

namespace SimpleStore.App.Products;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}
