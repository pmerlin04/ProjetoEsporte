using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEsporte.Model
{
    [Table("agendamento")]
    public class Agendamentos
    {
        [Key]
        [Column("id_agendamento", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAgendamento { get; set; }


        [Column("email_usuario", TypeName = "varchar(30)")]
        public string? EmailUsuario { get; set; }

        [ForeignKey("EmailUsuario")]
        public virtual Usuarios? Usuario { get; set; }


        [Column("id_quadra", TypeName = "int")]
        public int IdQuadra { get; set; }

        [ForeignKey("IdQuadra")]
        public virtual Quadras? Quadra { get; set; }

        [Column("dia_semana", TypeName = "varchar(30)")]
        public string? DiaSemana { get; set; }

        [Column("horario_inicio", TypeName = "datetime")]
        public DateTime HorarioInicio { get; set; }

        [Column("horario_final", TypeName = "datetime")]
        public DateTime HorarioFinal { get; set; }

        [Column("status_agendamento", TypeName = "varchar(30)")]
        public string? StatusAgendamento { get; set; }

        /*
        [Column("motivo_cancelamento", TypeName = "varchar(100)")]
        public string? MotivoCancelamento { get; set; }*/

    }
}
