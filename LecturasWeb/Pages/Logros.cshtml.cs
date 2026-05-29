using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LecturasWeb.Pages
{
    public class LogrosModel : PageModel
    {
        private readonly ILogrosNegocio _negocio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Conexion _context;


     public LogrosModel(
        ILogrosNegocio negocio,
        UserManager<IdentityUser> userManager,
        Conexion context)
        {
            _negocio = negocio;
            _userManager = userManager;
            _context = context;
        }

        public List<Libreria_Lecturas.Entidades.Logros> ListaLogros { get; set; } = new();

        public async Task OnGetAsync()
        {
           
            if (!User.Identity!.IsAuthenticated)
                return; // si no está logueado, lista vacía

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios
                .FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
                ListaLogros = _negocio.Consultar(usuarioDb.Id);
        }
    }

}


/* si queremos hacer logros personales
 * recordar que debemos agregar un campo UsuarioId en la tabla Logros, y luego filtrar por ese campo
 * hacer la migracion y el udapte para que esto pueda funcionar
   public async Task OnGetAsync()
        {
            if (!User.Identity!.IsAuthenticated)
                return; // si no está logueado, lista vacía

            var identityUser = await _userManager.GetUserAsync(User);
            var usuarioDb = _context.Usuarios
                .FirstOrDefault(u => u.Email == identityUser!.Email);

            if (usuarioDb != null)
                ListaLogros = _negocio.Consultar(usuarioDb.Id);
        } 
  */

