using System.Data.Entity;
using SpaUserControl.Domain.Entities;

namespace SpaUserControl.Data.Context
{
    public class AppContext : DbContext
    {

        public AppContext() : base("AppContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
