using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LecturasWeb.Pages
{
    public class MisLecturasModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public MisLecturasModel(UserManager<IdentityUser> userManager, Conexion context)
        {
            _userManager = userManager;
            _context = context;
        }

        public List<Libreria_Lecturas.Entidades.Lecturas> LecturasActivas { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Lecturas> LecturasTerminadas { get; set; } = new();


        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity!.IsAuthenticated)
                return RedirectToPage("/Account/Login");

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb == null) return RedirectToPage("/Account/Login");

            LecturasActivas = _context.Lecturas
                .Include(l => l._LibroId)
                .Include(l => l._ProgresoLecturas)
                .Where(l => l.UsuarioId == usuarioDb.Id && !l.Estado)
                .OrderByDescending(l => l.FechaInicio)
                .ToList();

            LecturasTerminadas = _context.Lecturas
                .Include(l => l._LibroId)
                .Where(l => l.UsuarioId == usuarioDb.Id && l.Estado)
                .OrderByDescending(l => l.FechaFin)
                .ToList();

            return Page();
        }
    }
}