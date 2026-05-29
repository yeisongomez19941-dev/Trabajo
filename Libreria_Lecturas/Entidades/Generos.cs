namespace Libreria_Lecturas.Entidades
{
    public class Generos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public List<Libros>? _Libros { get; set; }
    }
}
