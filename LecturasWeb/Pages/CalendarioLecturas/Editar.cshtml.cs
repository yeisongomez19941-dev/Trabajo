using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.CalendarioLecturas_Pages
{
    public class EditarModel : PageModel
    {
        private readonly ICalendarioLecturasNegocio _negocio;

        public EditarModel(ICalendarioLecturasNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.CalendarioLecturas Calendario { get; set; } = new();

        public void OnGet(int id)
        {
            Calendario = _negocio.Consultar().FirstOrDefault(c => c.Id == id)!;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Modificar(Calendario);
            return RedirectToPage("/CalendarioLecturas");
        }
    }
}