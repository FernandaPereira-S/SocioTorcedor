using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_SocioTorcedor
{
    [Table("time")]
    public class Time
    {
        [Key]
        [Column("idTime")]
        public int Id { get; set; }
        
        public string Nome { get; set; }

        public string Treinador { get; set; }

        public string Campeonatos { get; set; }

        public string EstadoOrigem { get; set; }
    }
}