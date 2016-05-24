using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=DataBaseConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public override int SaveChanges()
        {

            // Update metafields in entitys, that implement IBaseEntity - CreatedAtDT, etc
            var entities =
                ChangeTracker.Entries()
                .Where(x => x.Entity is IBaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((IBaseEntity)entity.Entity).CreatedAtDT = DateTime.Now;
                }

                ((IBaseEntity)entity.Entity).ModifiedAtDT = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}
