using System;
using System.Collections.Generic;
using System.Text;

namespace DatesTestTask.Core.Data
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
