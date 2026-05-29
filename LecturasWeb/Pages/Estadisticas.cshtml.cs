using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LecturasWeb.Pages
{
    public class EstadisticasModel : PageModel
    {
        private readonly IEstadisticasNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;
        public EstadisticasModel(
             IEstadisticasNegocio negocio,
             UserManager<IdentityUser> userManager,
             Conexion context)
             {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }
        

        public List<Libreria_Lecturas.Entidades.Estadisticas> ListaEstadisticas { get; set; } = new();

        public async Task OnGetAsync()
        {

            if (!User.Identity!.IsAuthenticated)
                return; // si no está logueado, lista vacía

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios
                .FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
                ListaEstadisticas = _negocio.Consultar(usuarioDb.Id);
        }
    }
}