using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class ConfiguracionUsuariosModel : PageModel
    {
        private readonly IConfiguracionUsuariosNegocio _negocio;

        public ConfiguracionUsuariosModel(IConfiguracionUsuariosNegocio negocio)
        {
            _negocio = negocio;
        }

        public List<Libreria_Lecturas.Entidades.ConfiguracionUsuarios> ListaConfiguraciones { get; set; } = new();

        public void OnGet()
        {
            ListaConfiguraciones = _negocio.Consultar();
        }
    }
}