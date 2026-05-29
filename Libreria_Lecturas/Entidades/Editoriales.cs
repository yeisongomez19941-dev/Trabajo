namespace Libreria_Lecturas.Entidades
{
    public class Editoriales
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Pais { get; set; }
        public DateTime? AnoFundacion { get; set; }
        public bool? Activa { get; set; }
    }
}
