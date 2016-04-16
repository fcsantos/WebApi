using CrudTeste.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CrudTeste.Infra.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");

            HasKey(x => x.Id);

            Property(x => x.Title).HasMaxLength(60).IsRequired();
        }
    }
}
