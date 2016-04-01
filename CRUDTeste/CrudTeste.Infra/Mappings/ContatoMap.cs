using CrudTeste.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CrudTeste.Infra.Mappings
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contato");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(200).IsRequired();
            Property(x => x.Telefone).IsRequired();
            Property(x => x.Data).IsRequired();

            HasRequired(x => x.Operadora);
        }
    }
}
