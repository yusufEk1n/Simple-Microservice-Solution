using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerWebApi
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
            try
            {
                /* Veritabanı mevcut değilse oluşturulur. */

                // IDatabaseCreator servisini kullanarak ilişkisel bir veritabanı oluşturucu nesnesini alıyoruz.
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

                if(databaseCreator != null)
                {
                    // Veritabanı bağlantısı sağlanamıyorsa oluşturulur.
                    if(!databaseCreator.CanConnect()) databaseCreator.Create();
                    // Veritabanı tabloları yoksa oluşturulur.
                    if(!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<Customer> Customers { get; set; } 
    }
}