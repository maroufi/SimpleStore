using MediatR;
using SimpleStore.App.Data;

namespace SimpleStore.App.Base;
public class TransactionBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, ICommand<TResponse>
{
    private readonly SimpleStoreDbContext _dbContext;

    public TransactionBehavior(SimpleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var hasTransactionalAttribute = typeof(TRequest).GetCustomAttributes(typeof(TransactionalAttribute), false).Any();

        if (!hasTransactionalAttribute)
        {
            return await next();
        }

        TResponse? response;
        try
        {
            await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            response = await next();

            await _dbContext.Database.CommitTransactionAsync(cancellationToken);
        }
        catch
        {
            await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
            throw;
        }

        return response;
    }
}
