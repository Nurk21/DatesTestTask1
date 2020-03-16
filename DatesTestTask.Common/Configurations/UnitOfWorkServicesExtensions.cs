using DatesTestTask.Core.Data;
using DatesTestTask.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DatesTestTask.Common.Configurations
{
    public static class UnitOfWorkServicesExtensions
    {
        public static IServiceCollection AddEfUnitOfWork<TContext>(this IServiceCollection services)
            where TContext : DbContext
        {
            services.AddTransient<IRepositoryFactory, EfUnitOfWork<TContext>>();
            services.AddTransient<IUnitOfWork, EfUnitOfWork<TContext>>();
            services.AddTransient<IUnitOfWork<TContext>, EfUnitOfWork<TContext>>();

            return services;
        }
    }
}
