namespace CrudTeste.Domain
{
    public class Operadora
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public decimal Preco { get; set; }
    }
}
