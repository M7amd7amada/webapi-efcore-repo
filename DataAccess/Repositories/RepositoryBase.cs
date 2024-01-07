using AutoMapper;

using DataAccess.Data;

using Domain.Interfaces;
using Domain.Settings;
using Domain.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace DataAccess.Repositories;

public class RepositoryBase<TEntity, TRequest, TResponse>
    : IRepositoryBase<TEntity, TRequest, TResponse>
    where TEntity : class
    where TRequest : class
    where TResponse : class
{
    private readonly AppSettings _appSettings;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly DbSet<TEntity> _entities;

    public RepositoryBase(
        AppDbContext context,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _context = context;
        _mapper = mapper;

        _appSettings = appSettings?.Value ?? new AppSettings();

        _entities = _context.Set<TEntity>();
    }

    public async Task<TResponse> DeleteAsync(TRequest request)
    {
        TEntity entity = _mapper.Map<TEntity>(request);

        if (!await _entities.ContainsAsync(entity))
        {
            throw new KeyNotFoundException($"Entity not found for deletion.");
        }

        _entities.Remove(entity);

        return _mapper.Map<TResponse>(entity);
    }

    public async Task<PagedResult<TResponse>> GetAllAsync(
        int page = 0,
        int pageSize = 0,
        Expression<Func<TEntity, object>> orderBy = null!,
        bool isDescending = false)
    {
        await Task.CompletedTask;

        page = (page <= 0) ? _appSettings.Pagination!.DefaultPage : page;
        pageSize = (pageSize <= 0) ? _appSettings.Pagination!.DefaultPageSize : pageSize;

        IQueryable<TEntity> query = _entities.AsNoTracking();

        if (orderBy is not null)
        {
            query = isDescending ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
        }

        PagedResult<TEntity> result = query.GetPaged(page, pageSize);

        return _mapper.Map<PagedResult<TResponse>>(result);
    }

    public async Task<TResponse> GetByIdAsync(Guid id)
    {
        TEntity entity = await _entities.FindAsync(id)
            ?? throw new KeyNotFoundException($"Entity with id {id} not found.");

        return _mapper.Map<TResponse>(entity);
    }

    public async Task<TResponse> InsertAsync(TRequest request)
    {
        TEntity entity = _mapper.Map<TEntity>(request);

        await _entities.AddAsync(entity);

        return _mapper.Map<TResponse>(entity);
    }

    public async Task<TResponse> UpdateAsync(TRequest request)
    {
        TEntity entity = _mapper.Map<TEntity>(request);

        if (!await _entities.ContainsAsync(entity))
        {
            throw new KeyNotFoundException($"Entity not found for updateing.");
        }

        _entities.Update(entity);

        return _mapper.Map<TResponse>(entity);
    }
}