using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vlad_Porime_Proiect.Data;
using Vlad_Porime_Proiect.Models;

namespace Vlad_Porime_Proiect.Pages.Shoes
{
    public class CreateModel : ShoeCategoriesPageModel
    {
        private readonly Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext _context;

        public CreateModel(Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["FactoryID"] = new SelectList(_context.Set<Factory>(), "ID", "FactoryName");
            var shoe = new Shoe();
            shoe.ShoeCategories = new List<ShoeCategory>();
            PopulateAssignedCategoryData(_context, shoe);
            return Page();
        }

        [BindProperty]
        public Shoe Shoe { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newShoe = new Shoe();
            if (selectedCategories != null)
            {
                newShoe.ShoeCategories = new List<ShoeCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new ShoeCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newShoe.ShoeCategories.Add(catToAdd);
                }
            }

            if (await TryUpdateModelAsync<Shoe>(
                newShoe,
                "Shoe",
                i => i.Brand, i => i.Model,
                i => i.Price, i => i.ReleaseDate, i => i.FactoryID))
            {
                _context.Shoe.Add(newShoe);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedCategoryData(_context, newShoe);
            return Page();

        }
    }
    
}
