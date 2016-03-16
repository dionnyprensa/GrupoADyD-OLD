using System;
using System.Collections.Generic;

namespace GrupoADyD.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PV { get; set; }
        public decimal BV { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public virtual ICollection<DetailedSale> DetailSale { get; set; }
        public virtual ICollection<ApplicationUser> Usuario { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}