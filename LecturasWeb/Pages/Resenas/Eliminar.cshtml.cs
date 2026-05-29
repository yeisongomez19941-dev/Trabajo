using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entidades = Libreria_Lecturas.Entidades;

namespace LecturasWeb.Pages.Resenas
{
    public class EliminarModel : PageModel
    {
        private readonly IResenasNegocio _negocio;

        public EliminarModel(IResenasNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Entidades.Resenas Resenas { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            // Include para traer los datos relacionados
            var resena = _negocio.Consultar().FirstOrDefault(r => r.Id == id);

            if (resena == null)
                return RedirectToPage("/Resenas/Index");

            Resenas = resena;
            return Page();
        }

        public IActionResult OnPost()
        {
            var resena = _negocio.Consultar().FirstOrDefault(r => r.Id == Resenas.Id);

            if (resena != null)
                _negocio.Borrar(resena);

            return RedirectToPage("/Resenas/Index");
        }
    }
}