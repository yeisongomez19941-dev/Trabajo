using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Interfaces;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LecturasWeb.Pages
{
    public class EditorialesModel : PageModel
    {
        private readonly IEditorialesNegocio _negocio;
        private readonly Conexion _context;

        public EditorialesModel(IEditorialesNegocio negocio, Conexion context)
        {
            _negocio = negocio;
            _context = context;
        }

        [BindProperty]
        public Libreria_Lecturas.Entidades.Editoriales Editorial { get; set; } = new();
        public List<Libreria_Lecturas.Entidades.Editoriales> ListaEditoriales { get; set; } = new();
        public string Mensaje { get; set; } = string.Empty;

        public void OnGet()
        {
            ListaEditoriales = _negocio.Consultar();
        }

        public IActionResult OnPostGuardar()
        {
            if (Editorial.Id == 0)
            {
                _negocio.Guardar(Editorial);
                AuditoriaHelper.Registrar(_context, "Editoriales", "Crear", User.Identity?.Name ?? "sistema", $"Editorial creada: \"{Editorial.Nombre}\"");
                Mensaje = "Editorial creada correctamente.";
            }
            else
            {
                _negocio.Modificar(Editorial);
                AuditoriaHelper.Registrar(_context, "Editoriales", "Modificar", User.Identity?.Name ?? "sistema", $"Editorial modificada: \"{Editorial.Nombre}\"");
                Mensaje = "Editorial actualizada correctamente.";
            }
            return RedirectToPage();
        }

        public IActionResult OnPostBorrar(int id)
        {
            var editorial = _negocio.Consultar().FirstOrDefault(e => e.Id == id);
            if (editorial != null)
            {
                AuditoriaHelper.Registrar(_context, "Editoriales", "Eliminar", User.Identity?.Name ?? "sistema", $"Editorial eliminada: \"{editorial.Nombre}\"");
                _negocio.Borrar(editorial);
            }
            return RedirectToPage();
        }
    }
}