using Libreria_Lecturas.Interfaces;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class CalendarioLecturasModel : PageModel
    {
        private readonly ICalendarioLecturasNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public CalendarioLecturasModel(
            ICalendarioLecturasNegocio negocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }

        public List<Libreria_Lecturas.Entidades.CalendarioLecturas> ListaCalendarioLecturas { get; set; } = new();

        public async Task OnGetAsync()
        {
            if (!User.Identity!.IsAuthenticated)
                return;

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
                ListaCalendarioLecturas = _negocio.Consultar(usuarioDb.Id);
        }
    }
}