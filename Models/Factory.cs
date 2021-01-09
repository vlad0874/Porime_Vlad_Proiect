using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlad_Porime_Proiect.Models
{
    public class Factory
    {
        public int ID { get; set; }
        public string FactoryName { get; set; }
        public ICollection<Shoe> Shoes { get; set; }
    }
}
