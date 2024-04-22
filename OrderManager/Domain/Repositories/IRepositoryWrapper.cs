namespace Domain.Repositories
{
    public interface IRepositoryWrapper
    {
        IOrderLineRepository OrderLine { get; }
        Task Save();
    }
}
