using System.Data.Entity.ModelConfiguration;
using Store.Model;

namespace Store.Data.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");
            Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
