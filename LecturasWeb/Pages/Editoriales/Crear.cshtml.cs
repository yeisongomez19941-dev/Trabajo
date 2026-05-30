using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Editoriales
{
    public class CrearModel : PageModel
    {
        private readonly IEditorialesNegocio _negocio;

        public CrearModel(IEditorialesNegocio negocio)
        {
            _negocio = negocio;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Editoriales Editoriales{ get; set; } = new();
        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _negocio.Guardar(Editoriales);
            return RedirectToPage("/Editoriales");
        }
    }
}
