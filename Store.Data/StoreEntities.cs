using System.Data.Entity;
using Store.Model;
using Store.Data.Configuration;

namespace Store.Data
{
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities")
        {

        }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public virtual void Commit()
        {
            // may we async?
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
