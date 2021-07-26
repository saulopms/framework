using Base.Repository.Models;
using System.Collections.Generic;

namespace Frutas.Models
{
    public class Carrinho: Entity
    {
        public List<ItemCarrinho> Itens { get; set; }
        public double TotalPedido { get; set; }
        public bool Finalizado { get; set; } = false;
    }
}
