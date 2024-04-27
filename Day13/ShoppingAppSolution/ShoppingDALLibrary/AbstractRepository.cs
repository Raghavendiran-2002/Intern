using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected List<T> items = new List<T>();
        public virtual async Task<T> Add(T item)
        {
            items.Add(item);
            return item;
        }
        public virtual async Task<ICollection<T>> GetAll()
        {
            items.Sort();
            return items;
            //return items.ToList<T>();
            
        }

        public abstract Task<T> Delete(K key);



        public abstract Task<T> GetByKey(K key);

        public abstract Task<T> Update(T item);

    }
}
