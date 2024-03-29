namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IFormRepository Forms { get; }

    public Task<bool> CompleteAsync();
}