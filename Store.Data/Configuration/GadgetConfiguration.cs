using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Data.Configuration
{
    public class GadgetConfiguration: EntityTypeConfiguration<Gadget>
    {
        public GadgetConfiguration()
        {
            ToTable("Gadgets");
            Property(x => x.Name).IsRequired().HasMaxLength(50);
            Property(x => x.Price).IsRequired().HasPrecision(8, 2);
            Property(x => x.CategoryID).IsRequired();
        }
    }
}
