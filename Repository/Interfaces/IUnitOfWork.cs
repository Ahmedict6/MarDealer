namespace Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
