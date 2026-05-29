using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Generos
{
    public class CrearModel : PageModel
    {
        private readonly IGenerosNegocio _negocio;

        public CrearModel(IGenerosNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Generos Generos { get; set; } = new();
      

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Generos);
            return RedirectToPage("/Generos");
        }
    }
}

