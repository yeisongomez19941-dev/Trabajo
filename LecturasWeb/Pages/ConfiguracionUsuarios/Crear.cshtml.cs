using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LecturasWeb.Pages.ConfiguracionUsuarios
{
    public class CrearModel : PageModel
    {
        private readonly IConfiguracionUsuariosNegocio _negocio;
        private readonly IAuditoriasNegocio _auditorias;

        public CrearModel(IConfiguracionUsuariosNegocio negocio, IAuditoriasNegocio auditorias)
        {
            _negocio = negocio;
            _auditorias = auditorias;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.ConfiguracionUsuarios Configuracion { get; set; } = new();

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Configuracion);
            _auditorias.Registrar("ConfiguracionUsuarios", "Crear",
            User.Identity?.Name ?? "Sistema", //Esto es para registrar el nombre del usuario que hizo la acción, si no hay un usuario autenticado, se registra como "Sistema"
            $"Configuración creada para usuario Id: {Configuracion.UsuarioId}");

            return RedirectToPage("/ConfiguracionUsuarios");
        }
    }
}