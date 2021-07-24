using Base.Repository.Models;

namespace Frutas.Models
{
    public class ItemCarrinho: Entity
    {
        public Fruta Item { get; set; }
    }
}
