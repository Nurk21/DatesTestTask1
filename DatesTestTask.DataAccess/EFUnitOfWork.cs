using DatesTestTask.Core.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatesTestTask.DataAccess
{
    public class EfUnitOfWork<TContext> : IUnitOfWork<TContext>, IRepositoryFactory, IDisposable
         where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly IConfiguration _config;

        private bool _disposed;

        private IDictionary<Type, object> _repositories;

        public EfUnitOfWork(TContext context, IConfiguration config)
        {
            _config = config;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new EfRepository<TEntity>(_context);

            return (IRepository<TEntity>)_repositories[type];
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception();
            }
        }

        public virtual async Task InsertBulkAsync(DataTable data, string tableName)
        {
            var connection = this.CreateConnection();

            using (connection)
            {
                using (var sqlBulk = new SqlBulkCopy(connection))
                {
                    connection.Open();
                    sqlBulk.BulkCopyTimeout = 60;
                    sqlBulk.DestinationTableName = tableName;
                    await sqlBulk.WriteToServerAsync(data);
                }
            }

        }

        [Obsolete]
        public virtual async Task ExecuteQueryAsync(string query)
        {
            await _context.Database.ExecuteSqlCommandAsync(query);
        }

        public virtual SqlConnection CreateConnection()
        {
            var connectionString = _config.GetSection("ConnectionStrings").GetChildren().FirstOrDefault(x => x.Key == "DefaultConnection")?.Value;
            return new SqlConnection(connectionString);
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                {
                    _repositories?.Clear();

                    _context.Dispose();
                }

            _disposed = true;
        }
    }
}

