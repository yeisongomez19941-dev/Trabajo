using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Autores_Pages
{
    public class EliminarModel : PageModel
    {
        private readonly IAutoresNegocio _negocio;

        public EliminarModel(IAutoresNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Autores Autor { get; set; } = new();

        public void OnGet(int id)
        {
            Autor = _negocio.Consultar().FirstOrDefault(a => a.Id == id)!;
        }

        public IActionResult OnPost()
        {
            _negocio.Borrar(Autor);
            return RedirectToPage("/Autores");
        }
    }
}