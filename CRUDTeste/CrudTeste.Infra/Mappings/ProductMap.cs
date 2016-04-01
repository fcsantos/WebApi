using CrudTeste.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CrudTeste.Infra.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
                
            HasKey(x => x.Id);

            Property(x => x.Title).HasMaxLength(60).IsRequired();
            Property(x => x.Price).IsRequired();
            Property(x => x.AcquireDate).IsRequired();

            HasRequired(x => x.Category);
        }
    }
}
