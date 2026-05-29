using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class AutoresModel : PageModel
    {
        private readonly IAutoresNegocio _negocio;

        public AutoresModel(IAutoresNegocio negocio)
        {
            _negocio = negocio;
        }

        public List<Libreria_Lecturas.Entidades.Autores> ListaAutores { get; set; } = new();

        public void OnGet()
        {
            ListaAutores = _negocio.Consultar();
        }
    }
}