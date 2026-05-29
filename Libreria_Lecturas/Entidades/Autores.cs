namespace Libreria_Lecturas.Entidades
{
    public class Autores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool? Activo { get; set; }

        public List<Libros>? _Libros { get; set; }
    }
}
