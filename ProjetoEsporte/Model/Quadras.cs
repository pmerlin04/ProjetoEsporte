using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEsporte.Model
{
    [Table("quadra")]
    public class Quadras
    {
        [Key]
        [Column("id_quadra", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdQuadra { get; set; }

        [Column("tipo_quadra", TypeName = "varchar(20)")]
        public string? TipoQuadra { get; set; }

        [Column("bola", TypeName = "bool")]
        public bool Bola { get; set; }
    }
}
