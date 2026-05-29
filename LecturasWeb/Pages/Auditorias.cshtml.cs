using Libreria_Lecturas.Entidades;
using Libreria_Lecturas.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuestPDF.Fluent;

namespace LecturasWeb.Pages
{
    public class AuditoriasModel : PageModel
    {
        private readonly Conexion _context;

        public AuditoriasModel(Conexion context)
        {
            _context = context;
        }

        public List<Auditorias> ListaAuditorias { get; set; } = new();

        public void OnGet()
        {
            ListaAuditorias = _context.Auditorias
                .OrderByDescending(a => a.Fecha)
                .ToList();
        }

        public IActionResult OnPostExportarPdf()
        {
            var auditorias = _context.Auditorias
                .OrderByDescending(a => a.Fecha)
                .ToList();

            var documento = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(QuestPDF.Helpers.PageSizes.A4);
                    page.Margin(30);

                    page.Header().Text("Reporte de Auditorías")
                        .FontSize(20).Bold().FontColor("#1a1a2e");

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(4);
                        });

                        // Encabezados
                        table.Header(header =>
                        {
                            header.Cell().Text("Tabla").Bold();
                            header.Cell().Text("Acción").Bold();
                            header.Cell().Text("Usuario").Bold();
                            header.Cell().Text("Fecha").Bold();
                            header.Cell().Text("Detalle").Bold();
                        });

                        // Filas
                        foreach (var a in auditorias)
                        {
                            table.Cell().Text(a.Tabla ?? "");
                            table.Cell().Text(a.Accion ?? "");
                            table.Cell().Text(a.UsuarioEmail ?? "");
                            table.Cell().Text(a.Fecha.ToString("dd/MM/yyyy HH:mm"));
                            table.Cell().Text(a.Detalle ?? "");
                        }
                    });

                    page.Footer().Text(text =>
                    {
                        text.Span("Generado el ");
                        text.Span(DateTime.Now.ToString("dd/MM/yyyy HH:mm")).Bold();
                    });
                });
            });

            var pdf = documento.GeneratePdf();
            return File(pdf, "application/pdf", $"Auditoria_{DateTime.Now:yyyyMMdd}.pdf");
        }
    }
}