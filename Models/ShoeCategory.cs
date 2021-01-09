using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlad_Porime_Proiect.Models
{
    public class ShoeCategory
    {
        public int ID { get; set; }
        public int ShoeID { get; set; }
        public Shoe Shoe { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
