namespace Domain.Repositories
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        Task Save();
    }
}
