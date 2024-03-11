namespace RepositoryAssignment
{
    public interface IRepository<T> 
    {
        void Add(T entity);

        void Delete(T entity);

        void DeleteById(string id);

        IEnumerable<T> GetAll();

        T GetById(string id);

        int GetCount();

        void RemoveRange(IEnumerable<T> entitiesToRemove);
    }
}
