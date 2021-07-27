namespace Frutas.Models.Dto
{
    public class FrutaDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
