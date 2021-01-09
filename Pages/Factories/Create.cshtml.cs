using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vlad_Porime_Proiect.Data;
using Vlad_Porime_Proiect.Models;

namespace Vlad_Porime_Proiect.Pages.Factories
{
    public class CreateModel : PageModel
    {
        private readonly Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext _context;

        public CreateModel(Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FactoryID"]= new SelectList(_context.Set<Factory>(), "ID", "FactoryName");
            return Page();
        }

        [BindProperty]
        public Factory Factory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Factory.Add(Factory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
