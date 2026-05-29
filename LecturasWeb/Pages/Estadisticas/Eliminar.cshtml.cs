using Libreria_Lecturas.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages.Estadisticas
{
    public class EliminarModel : PageModel
    {
    
            private readonly IEstadisticasNegocio _negocio;

            public EliminarModel(IEstadisticasNegocio negocio)
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
                _negocio.Borrar(Estadisticas);
                return RedirectToPage("/Estadisticas");
            }
        }
    }
