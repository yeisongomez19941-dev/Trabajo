using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_Lecturas.Entidades
{
    public class Notificaciones
    {
        public int Id { get; set; }
        public string? Mensaje { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public bool? Leida { get; set; }
        public int? UsuarioId { get; set; }


        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }
    }
}
