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

namespace Vlad_Porime_Proiect.Pages.Shoes
{
    public class EditModel : ShoeCategoriesPageModel
    {
        private readonly Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext _context;

        public EditModel(Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shoe Shoe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shoe = await _context.Shoe
                .Include(b => b.Factory)
                .Include(b => b.ShoeCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Shoe == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Shoe);
            ViewData["FactoryID"] = new SelectList(_context.Set<Factory>(), "ID", "FactoryName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound() ;
            }

            var shoeToUpdate = await _context.Shoe
                .Include(i => i.Factory)
                .Include(i => i.ShoeCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if(shoeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Shoe>(
                shoeToUpdate,
                "Shoe",
                i => i.Brand, i=> i.Model,
                i=> i.Price, i=> i.ReleaseDate, i => i.Factory))
            {
                UpdateShoeCategories(_context, selectedCategories, shoeToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateShoeCategories(_context, selectedCategories, shoeToUpdate);
            PopulateAssignedCategoryData(_context, shoeToUpdate);
            return Page();
          
        }
    }
}
