using MediatR;

namespace SimpleStore.App.Products;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
