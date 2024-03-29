using System.Linq.Expressions;

using Domain.Data;

namespace Domain.Interfaces;

public interface IRepositoryBase<TEntity, TRequest, TResponse>
    where TEntity : class
    where TRequest : class
    where TResponse : class
{
    public Task<PagedResult<TResponse>> GetAllAsync(
        int page,
        int pageSize,
        Expression<Func<TEntity, object>> orderBy,
        bool isDescending);
    public Task<TResponse> GetByIdAsync(Guid id);
    public Task<TResponse> DeleteAsync(TRequest request);
    public Task<TResponse> InsertAsync(TRequest request);
    public Task<TResponse> UpdateAsync(TRequest request);
}