using DatesTestTask.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatesTestTask.DataAccess
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        #region Ctor

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Fields

        private readonly DbContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Methods

        /// <summary>
        ///     Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public async Task<T> GetByIdAsync(Guid id)
        {
 
                return await Entities.FindAsync(id);
           
        }

        /// <summary>
        ///     Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public T GetById(Guid id)
        {            
                return Entities.Find(id);     
        }

        /// <summary>
        ///     InsertMany entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Add(entity);
        }

        /// <summary>
        ///     InsertMany entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void InsertMany(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
                Entities.Add(entity);
        }

        public virtual async Task InsertManyAsync(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
                await Entities.AddRangeAsync(entity);
        }

        /// <summary>
        ///     UpdateMany entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Update(entity);
        }

        /// <summary>
        ///     UpdateMany entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void UpdateMany(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities) Entities.Update(entity);
        }

        /// <summary>
        ///     Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
        }

        /// <summary>
        ///     Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            Entities.RemoveRange(entities);
        }
        #endregion

        #region Properties

        /// <summary>
        ///     Gets a table
        /// </summary>
        public virtual IQueryable<T> Table => Entities;

        /// <summary>
        ///     Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only
        ///     operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        /// <summary>
        ///     Entities
        /// </summary>
        protected virtual DbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

        #endregion
    }
}
