using DatesTestTask.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace DatesTestTask.DataAccess
{
    public class DataContext: DbContext
    {
        public DbSet<DatesRange> Ranges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-126LHOT8\\SQLEXPRESS; Initial Catalog=DatesTestTask;Integrated Security=True");
                    }

    }
}
