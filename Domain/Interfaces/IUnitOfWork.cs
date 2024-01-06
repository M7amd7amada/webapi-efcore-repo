namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public Task<int> CompleteAsync();
}