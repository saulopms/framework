using Frutas.Models.Dto;
using System.Collections.Generic;

namespace Frutas.Models.ViewModel
{
    public class CarrinhoViewModel
    {
        public List<FrutaDto> Itens { get; set; }
        public double TotalPedido { get; set; }
        public bool Finalizado { get; set; }
    }
}
