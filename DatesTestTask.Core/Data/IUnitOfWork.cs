using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DatesTestTask.Core.Data
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();

        Task InsertBulkAsync(DataTable data, string tableName);

        Task ExecuteQueryAsync(string query);

        SqlConnection CreateConnection();
    }

    // ReSharper disable once UnusedTypeParameter
    public interface IUnitOfWork<TContext> : IUnitOfWork
    {
    }
}
