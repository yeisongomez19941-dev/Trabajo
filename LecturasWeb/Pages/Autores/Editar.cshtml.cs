using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Autores_Pages
{
    public class EditarModel : PageModel
    {
        private readonly IAutoresNegocio _negocio;

        public EditarModel(IAutoresNegocio negocio)
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
            if (!ModelState.IsValid) return Page();
            _negocio.Modificar(Autor);
            return RedirectToPage("/Autores");
        }
    }
}