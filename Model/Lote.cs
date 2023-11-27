using System.ComponentModel.DataAnnotations;

namespace Varejao.Model
{
    public class Lote
    {
        public Lote() { }
        [Key]
        public int IdLote { get; set; }
        public int QuantidadeHortifruti { get; set; }
        public DateTime DataValidade { get; set; }
        public int IdHortifruti { get; set; }
        public string Fornecedor { get; set; }
        public virtual Hortifruti Hortifruti { get; set;}

    }
}
