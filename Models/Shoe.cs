using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vlad_Porime_Proiect.Models
{
    public class Shoe
    {
        public int ID { get; set; }
        [Display(Name ="Shoe brand")]

     
        [RegularExpression(@"^[A-Z][a-z]+$" , ErrorMessage= "numele brandului trebuie sa aiba minim 3 caractere si sa inceapa cu litera mare"), Required,
        StringLength(50, MinimumLength = 3)]
        public string Brand { get; set; }
        public string Model { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int FactoryID { get; set; }

        public Factory Factory { get; set; }

        public ICollection<ShoeCategory> ShoeCategories{ get; set; }



    }
}
