namespace Frutas.Models
{
    public class ItemCarrinho
    {
        public long Id { get; set; }
        public long CarrinhoId { get; set; }
        public long FrutaId { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
