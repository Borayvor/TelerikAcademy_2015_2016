namespace SchoolSystem.Framework.Core.Repositories
{
    using System.Collections.Generic;
    using Contracts.Repositories;

    public class DictionaryDbRepository<T> : IDbRepository<T>
        where T : class
    {
        private static IDictionary<int, T> entities;
        private static int currentEntityId;

        public DictionaryDbRepository()
        {
            entities = new Dictionary<int, T>();
            currentEntityId = 0;
        }

        public int Add(T entity)
        {
            var id = currentEntityId;
            entities.Add(currentEntityId++, entity);

            return id;
        }

        public T GetById(int id)
        {
            if (!entities.ContainsKey(id))
            {
                return null;
            }

            return entities[id];
        }

        public void Remove(int id)
        {
            if (entities.ContainsKey(id))
            {
                entities.Remove(id);
            }
        }
    }
}
