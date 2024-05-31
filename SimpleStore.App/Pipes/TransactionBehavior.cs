using MediatR;
using SimpleStore.App.Data;
using SimpleStore.App.Products;

namespace SimpleStore.App.Pipes;
public class TransactionBehavior<TRequest, TResponse> : 
    IPipelineBehavior<TRequest, TResponse> where TRequest : notnull, ICommand
{
    private readonly SimpleStoreDbContext _dbContext;

    public TransactionBehavior(SimpleStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse? response;
        try
        {
            await _dbContext.Database.BeginTransactionAsync(cancellationToken);

            response = await next();

            //await _dbContext.SaveChangesAsync(cancellationToken);
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
