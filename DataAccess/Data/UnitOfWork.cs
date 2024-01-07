using AutoMapper;

using DataAccess.Repositories;

using Domain.Interfaces;
using Domain.Settings;

using Microsoft.Extensions.Options;

namespace DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context, IMapper mapper, IOptions<AppSettings> appSettings)
    {
        _context = context;

        Forms = new FormRepository(context, mapper, appSettings);
    }
    public IFormRepository Forms { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }
}