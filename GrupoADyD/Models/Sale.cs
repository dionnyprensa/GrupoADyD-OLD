using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoADyD.Models
{
    public class Sale
    {
        [DisplayName("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaleId { get; set; }

        public decimal Total { get; set; }

        public virtual Client Client { get; set; }
        public virtual DetailedSale DetailedSale { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [DisplayName("Usuario")]
        public virtual ApplicationUser User { get; set; }

        [DisplayName("Fecha de Creacion")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [DisplayName("Fecha de Modificacion")]
        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }
    }
}