using System;

namespace GrupoADyD.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PV { get; set; }
        public decimal BV { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}