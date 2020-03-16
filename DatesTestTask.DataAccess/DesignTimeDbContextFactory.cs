using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatesTestTask.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-126LHOT8\\SQLEXPRESS; Initial Catalog=StoryMap;Integrated Security=True");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
