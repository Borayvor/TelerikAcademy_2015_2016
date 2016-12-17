namespace SchoolSystem.Framework.Core.Contracts.Repositories
{
    public interface IDbRepository<T> where T : class
    {
        int Add(T entity);

        void Remove(int id);

        T GetById(int id);
    }
}
