using CrudTeste.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CrudTeste.Infra.Mappings
{
    public class OperadoraMap : EntityTypeConfiguration<Operadora>
    {
        public OperadoraMap()
        {
            ToTable("Operadora");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();
            Property(x => x.Preco).IsRequired();
            Property(x => x.Codigo).IsRequired();

            HasRequired(x => x.Category);
        }
    }
}
