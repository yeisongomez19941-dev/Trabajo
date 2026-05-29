using Libreria_Lecturas.Interfaces;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace LecturasWeb.Pages
{
    public class FavoritosModel : PageModel
    {
        private readonly IFavoritosNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Libreria_Lecturas.Implementaciones.Conexion _context;

        public FavoritosModel(
            IFavoritosNegocio negocio,
            UserManager<IdentityUser> userManager,
            Libreria_Lecturas.Implementaciones.Conexion context)
        {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }

        public List<Libreria_Lecturas.Entidades.Favoritos> ListaFavoritos { get; set; } = new();

        public async Task OnGetAsync()
        {
            if (!User.Identity!.IsAuthenticated)
                return; // si no está logueado, lista vacía

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios
                .FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
                ListaFavoritos = _negocio.Consultar(usuarioDb.Id);
        }
    }
}