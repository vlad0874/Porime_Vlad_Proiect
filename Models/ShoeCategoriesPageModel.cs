using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vlad_Porime_Proiect.Data;

namespace Vlad_Porime_Proiect.Models
{
    public class ShoeCategoriesPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Vlad_Porime_ProiectContext context, Shoe shoe)
        {
            var allCategories = context.Category;
            var shoeCategories = new HashSet<int>(
                shoe.ShoeCategories.Select(c => c.ShoeID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
              foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryId = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = shoeCategories.Contains(cat.ID)
                });
            }

        }

        public void UpdateShoeCategories (Vlad_Porime_ProiectContext context, string[] selectedCategories, Shoe shoeToUpdate)
        {
            if(selectedCategories == null)
            {
                shoeToUpdate.ShoeCategories = new List<ShoeCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var shoeCategories = new HashSet<int>
                (shoeToUpdate.ShoeCategories.Select(c => c.CategoryID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!shoeCategories.Contains(cat.ID))
                    {
                        shoeToUpdate.ShoeCategories.Add(
                            new ShoeCategory
                            {
                                ShoeID = shoeToUpdate.ID,
                                CategoryID = cat.ID
                            });
                    }
                }
                else
                {
                    if (shoeCategories.Contains(cat.ID))
                    {
                        ShoeCategory courseToRemove = shoeToUpdate.ShoeCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);

                    }
                }
            }
        }

    }
}
