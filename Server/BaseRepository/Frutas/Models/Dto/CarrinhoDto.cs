using System.Collections.Generic;

namespace Frutas.Models.Dto
{
    public class CarrinhoDto
    {
        public long Id { get; set; }
        public List<ItemCarrinho> Itens { get; set; }
        public double TotalPedido { get; set; }
        public bool Finalizado { get; set; }
    }
}
