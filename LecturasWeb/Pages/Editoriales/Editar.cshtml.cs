using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Editoriales
{
    public class EditarModel : PageModel
    {
        private readonly IEditorialesNegocio _negocio;

        public EditarModel(IEditorialesNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Editoriales Editoriales { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            Editoriales = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;
            if (Editoriales == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Modificar(Editoriales);
            return RedirectToPage("/Editoriales");
        }
    }
}

