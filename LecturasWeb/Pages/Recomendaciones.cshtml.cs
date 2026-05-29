using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class RecomendacionesModel : PageModel
    {
        private readonly IRecomendacionesNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;

        public RecomendacionesModel(
            IRecomendacionesNegocio negocio,
            UserManager<IdentityUser> userManager,
            Conexion context)
        {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }

        public List<Libreria_Lecturas.Entidades.Recomendaciones> ListaRecomendaciones { get; set; } = new();

        public async Task OnGetAsync()
        {
            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
            {
                ListaRecomendaciones = _negocio.GenerarRecomendaciones(usuarioDb.Id);
            }
        }
    }
}