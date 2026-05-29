using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria_Lecturas.Entidades
{
    public class ProgresoLecturas
    {
        public int Id { get; set; }
        public int PaginasLeidas { get; set; }
        public decimal Porcentaje { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? LecturaId { get; set; }


        [ForeignKey("LecturaId")]
        public Lecturas? _LecturaId { get; set; }

        public void CalcularPorcentaje(int totalPaginas)
        {
            Porcentaje = (decimal)PaginasLeidas / totalPaginas * 100;
        }
    }
}
