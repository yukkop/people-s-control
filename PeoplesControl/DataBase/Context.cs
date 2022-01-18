using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;

namespace DataBase
{
    public class Context: DbContext
    {
        string _connectionString;
        public Context(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        public Context(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public async System.Threading.Tasks.Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                //handle with some logger
                return false;
            }

            return true;
        }
        public bool SaveChanges()
        {
            try
            {
                base.SaveChanges();
            }
            catch (Exception e)
            {
                //handle with some logger
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
        public bool Update<TEntity>(TEntity entity)
        {
            try
            {
                base.Update(entity);
            }
            catch (Exception e)
            {
                //handle with some logger
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
