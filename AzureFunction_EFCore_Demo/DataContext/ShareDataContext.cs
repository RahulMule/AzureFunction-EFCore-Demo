using AzureFunction_EFCore_Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction_EFCore_Demo.DataContext
{
    public class ShareDataContext : DbContext
    {
        public ShareDataContext()
        {

        }
        public ShareDataContext(DbContextOptions<ShareDataContext> options) : base(options)
        {
            
        }

        

        public DbSet<Share> Shares { get; set; }   
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship between Stock and StockTransaction
            modelBuilder.Entity<Stock>()
                .HasMany(s => s.StockTransactions)
                .WithOne(t => t.Stock)
                .HasForeignKey(t => t.StockID);


            base.OnModelCreating(modelBuilder);
        }
    }

    public class ShareDataContextFactory : IDesignTimeDbContextFactory<ShareDataContext>
    {
        public ShareDataContext CreateDbContext(string[] args)
        {
            string connstring = "Server=localhost\\SQLEXPRESS;Database=Test;Trusted_Connection=True;TrustServerCertificate=True;"; //Environment.GetEnvironmentVariable("ConnectionStrings");
            var builder = new DbContextOptionsBuilder<ShareDataContext>()
                .UseSqlServer(connstring);
            return new ShareDataContext(builder.Options);

        }
    }
}
