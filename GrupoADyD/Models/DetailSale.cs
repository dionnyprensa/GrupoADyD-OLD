using System;
using System.Collections.Generic;

namespace GrupoADyD.Models
{
    public class DetailSale
    {
        public int DetailSaleId { get; set; }
        public decimal PVs { get; set; }
        public decimal BVs { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}