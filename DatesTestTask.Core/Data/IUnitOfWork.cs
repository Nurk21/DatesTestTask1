using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace DatesTestTask.Core.Data
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();


        Task ExecuteQueryAsync(string query);

        SqlConnection CreateConnection();
    }

    // ReSharper disable once UnusedTypeParameter
    public interface IUnitOfWork<TContext> : IUnitOfWork
    {
    }
}
