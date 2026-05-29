using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class GenerosModel : PageModel
    {
        private readonly IGenerosNegocio _negocio;

        public GenerosModel(IGenerosNegocio negocio)
        {
            _negocio = negocio;
        }

        public List<Libreria_Lecturas.Entidades.Generos> ListaGeneros { get; set; } = new();

        public void OnGet()
        {
            ListaGeneros = _negocio.Consultar();
        }
    }
}