using System.Data.Entity;
using System.Reflection;

namespace EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("sql")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MyDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Text> Text { get; set; }
    }
}
