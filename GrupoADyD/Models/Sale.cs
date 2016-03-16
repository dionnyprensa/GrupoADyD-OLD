using System;

namespace GrupoADyD.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public virtual Client Client { get; set; }
        public ApplicationUser IBO { get; set; }
        public virtual DetailSale DetailSale { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}