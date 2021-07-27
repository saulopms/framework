using System.Collections.Generic;

namespace Frutas.Models.Dto
{
    public class CarrinhoViewDto
    {
        public List<FrutaDto> Itens { get; set; }
        public double TotalPedido { get; set; }
        public bool Finalizado { get; set; }
    }
}
