using MediatR;

namespace SimpleStore.App.Base;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
