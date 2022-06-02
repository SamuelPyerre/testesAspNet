using Microsoft.EntityFrameworkCore;
using MyDebtsApi.Model;

namespace MyDebtsApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DividaModel> Dividas {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite("DataSource=app.db;Cache=Shared");
    }
}