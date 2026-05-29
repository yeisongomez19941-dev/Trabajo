using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Estadisticas
{
    public class EditarModel : PageModel
    {
            private readonly IEstadisticasNegocio _negocio;

            public EditarModel(IEstadisticasNegocio negocio)
            {
                _negocio = negocio;
            }

            [BindProperty]
            public Libreria_Lecturas.Entidades.Estadisticas Estadisticas { get; set; } = new();

            public IActionResult OnGet(int id)
            {
                Estadisticas = _negocio.Consultar().FirstOrDefault(l => l.Id == id)!;
                if (Estadisticas == null) return NotFound();
                return Page();
            }

            public IActionResult OnPost()
            {
                if (!ModelState.IsValid) return Page();
                _negocio.Modificar(Estadisticas);
                return RedirectToPage("/Estadisticas");
            }
        }
    }

