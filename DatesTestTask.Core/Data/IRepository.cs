using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatesTestTask.Core.Data
{
    public interface IRepository<T>
    {
        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }
        Task<T> GetByIdAsync(Guid id);

        T GetById(Guid id);

        void Insert(T entity);

        void InsertMany(IEnumerable<T> entities);

        Task InsertManyAsync(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateMany(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);
    }
}
