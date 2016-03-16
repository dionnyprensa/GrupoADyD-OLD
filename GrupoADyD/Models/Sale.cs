using System;

namespace GrupoADyD.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public decimal Total { get; set; }

        public virtual Client Client { get; set; }
        public virtual DetailedSale DetailSale { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}