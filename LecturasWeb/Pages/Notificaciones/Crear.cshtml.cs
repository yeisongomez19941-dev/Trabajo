using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Notificaciones
{
    public class CrearModel : PageModel
    {
        private readonly INotificacionesNegocio _negocio;

        //se agrega el contexto para poder obtener el id del usuario que esta creando la notificacion
        private readonly Conexion _context;

        public CrearModel(INotificacionesNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
        }
        //hasta aca van los cambios que se realizan para que funcione la relacion entre notificaciones y usuarios, el resto del codigo es igual al de las otras paginas de creacion


        [BindProperty]
        public Libreria_Lecturas.Entidades.Notificaciones Notificaciones { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Usuarios> ListaUsuarios { get; set; } = new(); // se crea la lista de usuarios para mostrarla en el select del formulario
        public void OnGet()
        {
            ListaUsuarios = _context.Usuarios.ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Notificaciones);
            return RedirectToPage("/Notificaciones");
        }
    }
}



