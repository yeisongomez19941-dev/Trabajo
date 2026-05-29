namespace Libreria_Lecturas.Entidades
{
    public class SeccionLecturas
    {
        public int Id { get; set; }
        public int PaginasLeidas { get; set; }
        public decimal MinutosLeidos { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
