namespace Domain.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISetupRepository Setup { get; }
        Task Save();
    }
}
