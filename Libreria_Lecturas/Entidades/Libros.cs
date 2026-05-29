using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
    public class Libros
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public int PaginasTotales { get; set; }
        public DateTime? AnoPublicacion { get; set; }
        public int? AutorId { get; set; }
        public int? GeneroId { get; set; }


        [ForeignKey("AutorId")]
        public Autores? _AutorId { get; set; }

        [ForeignKey("GeneroId")]
        public Generos? _GeneroId { get; set; }

        public List<Lecturas>? _Lecturas { get; set; }
        public List<Favoritos>? _Favoritos { get; set; }
        public List<Resenas>? _Resenas { get; set; }

        public int CalcularTiempoLectura(int paginasPorDia)
        {
            return PaginasTotales / paginasPorDia;
        }
        //agregar sinopsis para los libros
        public string? Sinopsis { get; set; }
        public string? ImagenUrl { get; set; } //agregar url de imagen para los libros
    }
}
