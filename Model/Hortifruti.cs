using System.ComponentModel.DataAnnotations;

namespace Varejao.Model
{
    public class Hortifruti
    {
        [Key]
        public int IdHortifruti { get; set; }
        public string Nome { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueAtual { get; set; }
        public float PrecoCusto { get; set; }
        public float PrecoVenda { get; set; }
        public float Icms { get; set; }
        public float Iss { get; set; }
        public float Cofins { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }
    }
}
