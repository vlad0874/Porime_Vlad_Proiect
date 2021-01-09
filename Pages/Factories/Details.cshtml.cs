﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vlad_Porime_Proiect.Data;
using Vlad_Porime_Proiect.Models;

namespace Vlad_Porime_Proiect.Pages.Factories
{
    public class DetailsModel : PageModel
    {
        private readonly Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext _context;

        public DetailsModel(Vlad_Porime_Proiect.Data.Vlad_Porime_ProiectContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
