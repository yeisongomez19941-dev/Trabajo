using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria_Lecturas.Entidades
{
    public class Logros
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int Puntos { get; set; }
        public bool? Activo { get; set; }
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuarios? _UsuarioId { get; set; }
    }
}
