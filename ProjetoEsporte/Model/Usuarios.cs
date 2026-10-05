using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEsporte.Model
{
    [Table("usuario")]
    public class Usuarios
    {
        [Key]
        [Column("email_usuario", TypeName = "varchar(30)")]
        public string EmailUsuario { get; set; }

        [Column("id_usuario", TypeName = "int")]
        public int IdUsuario { get; set; }

        [Column("nome_usuario", TypeName = "varchar(100)")]
        public string? NomeUsuario { get; set; }

    }
}
