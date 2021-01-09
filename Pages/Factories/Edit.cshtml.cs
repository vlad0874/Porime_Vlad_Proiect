using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vlad_Porime_Proiect.Data;
using Vlad_Porime_Proiect.Models;

namespace Vlad_Porime_Proiect.Pages.Factories
{
    public class EditModel : PageModel
    {
        private readonly Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext _context;

        public EditModel(Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Factory Factory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Factory = await _context.Factory.FirstOrDefaultAsync(m => m.ID == id);

            if (Factory == null)
            {
                return NotFound();
            }
            ViewData["FactoryID"]= new SelectList(_context.Set<Factory>(), "ID", "FactoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Factory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoryExists(Factory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FactoryExists(int id)
        {
            return _context.Factory.Any(e => e.ID == id);
        }
    }
}
