using System.Collections.Generic;

namespace GrupoADyD.Models
{
    public class DetailedSale
    {
        public int detailedSaleId { get; set; }
        public decimal PVs { get; set; }
        public decimal BVs { get; set; }
        public decimal Discount { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Client Client { get; set; }
    }
}