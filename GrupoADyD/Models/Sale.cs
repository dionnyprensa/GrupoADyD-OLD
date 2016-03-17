using System;
using System.ComponentModel;

namespace GrupoADyD.Models
{
    public class Sale
    {
        [DisplayName("Id")]
        public int SaleId { get; set; }

        public decimal Total { get; set; }

        public virtual Client Client { get; set; }
        public virtual DetailedSale DetailedSale { get; set; }

        [DisplayName("Usuario")]
        public ApplicationUser UserName { get; set; }

        [DisplayName("Fecha de Creacion")]
        public DateTime CreationDate { get; set; }

        [DisplayName("Fecha de Modificacion")]
        public DateTime ModificationDate { get; set; }
    }
}