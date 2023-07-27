using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_SocioTorcedor
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [Column("idCategoria")]
        public int Id { get; set; }

        public string Nome { get; set; }

        public float Preco { get; set; }

        public string Beneficios {  get; set; }

    }
}