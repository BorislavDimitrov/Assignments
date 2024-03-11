
namespace RepositoryAssignment
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _entities = new List<T>();

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(string id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

        public int GetCount()
        {
            return _entities.Count();
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteById(string id)
        {
            var entityToDelete = _entities.FirstOrDefault( x => x.Id == id);

            _entities.Remove(entityToDelete);
        }

        public void RemoveRange(IEnumerable<T> entitiesToRemove)
        {
            foreach (T entity in entitiesToRemove) 
            { 
                _entities.Remove(entity);
            }
        }
    }
}
