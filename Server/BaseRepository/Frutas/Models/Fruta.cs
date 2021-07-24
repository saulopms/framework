using Base.Repository.Models;

namespace Frutas.Models
{
    public class Fruta: Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
