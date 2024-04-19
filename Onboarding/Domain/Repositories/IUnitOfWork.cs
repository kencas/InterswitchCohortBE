namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Save(CancellationToken cancellationToken);
        
    }
}
