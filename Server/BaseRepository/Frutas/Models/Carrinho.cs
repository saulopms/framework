using Base.Repository.Models;
using System.Collections.Generic;

namespace Frutas.Models
{
    public class Carrinho: Entity
    {
        public IEnumerable<ItemCarrinho> Itens { get; set; }
        public double TotalPedido { get; set; }
    }
}
