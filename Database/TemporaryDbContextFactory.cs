using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Mimilo.Database
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<MimiloContext>
    {
        public MimiloContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MimiloContext>(); 
            IConfigurationRoot configuration = new ConfigurationBuilder()  
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)       
            .AddJsonFile("appsettings.json")
            .Build();

            builder.UseSqlServer(configuration.GetConnectionString("MimiloDatabase")); 
            return new MimiloContext(builder.Options); 
        }
    }
}