using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Generos
{
    public class EditarModel : PageModel
    {
        private readonly IGenerosNegocio _negocio;

        public EditarModel(IGenerosNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Generos Generos { get; set; } = new();

        public void OnGet(int id)
        {
            Generos = _negocio.Consultar().FirstOrDefault(a => a.Id == id)!;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Modificar(Generos);
            return RedirectToPage("/Generos");
        }
    }
}

