using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.CalendarioLecturas_Pages
{
    public class CrearModel : PageModel
    {
        private readonly ICalendarioLecturasNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public CrearModel(
            ICalendarioLecturasNegocio negocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.CalendarioLecturas Calendario { get; set; } = new()
        {
            Fecha = DateTime.Now
        };

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
                Calendario.UsuarioId = usuarioDb.Id;
            _negocio.Guardar(Calendario);
            AuditoriaHelper.Registrar(_context, "Calendario", "Crear", User.Identity?.Name ?? "sistema", $"Calendario creado: \"{Calendario}\"");
            return RedirectToPage("/CalendarioLecturas");
        }
    }
}