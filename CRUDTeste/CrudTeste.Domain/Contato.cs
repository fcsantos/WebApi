using System;

namespace CrudTeste.Domain
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int OperadoraId { get; set; }
        public virtual Operadora Operadora { get; set; }
        public DateTime Data { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
