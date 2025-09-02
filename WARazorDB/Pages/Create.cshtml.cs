using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WARazorDB.Data;
using WARazorDB.Models;

namespace WARazorDB.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WARazorDB.Data.TareaDbContext _context;

        public CreateModel(WARazorDB.Data.TareaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Inicializar la tarea con estado "Pendiente" por defecto
            Tarea = new Tarea
            {
                estado = "Pendiente",
                fechaVencimiento = DateTime.Today.AddDays(1) // Fecha por defecto: mañana
            };
            return Page();
        }

        [BindProperty]
        public Tarea Tarea { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Forzar el estado a "Pendiente" en Create
            Tarea.estado = "Pendiente";
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tareas.Add(Tarea);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
