using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Entidades;



namespace Libreria_Lecturas.Interfaces
{
    public interface ICalendarioLecturasNegocio
    {
        List<CalendarioLecturas> Consultar();
        List<CalendarioLecturas> Consultar(int usuarioId); //Esto es para consultar por usuario el calendario de lecturas
        CalendarioLecturas Guardar(CalendarioLecturas entidad);
        CalendarioLecturas Modificar(CalendarioLecturas entidad);
        bool Borrar(CalendarioLecturas entidad);
    }
}
