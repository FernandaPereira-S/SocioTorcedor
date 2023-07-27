using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_SocioTorcedor
{
    [Table("torcedor")]
    public class Torcedor
    {
        [Key]
        [Column("idTorcedor")]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public int IdTime { get; set; }
        
        [ForeignKey("IdTime")]
        public virtual Time? Time { get; set; }    

        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }
    }
}