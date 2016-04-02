using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoADyD.Models
{
    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int SaleId { get; set; }

        [DisplayName("# de Venta")]
        public ushort SalesNumber { get; set; }

        [DisplayName("Cliente")]
        public int ClientId { get; set; }

        [DisplayName("Detalles")]
        public int DetaildSaledId { get; set; }

        [DisplayName("Total")]
        public decimal Total { get; set; }

        public virtual Client Client { get; set; }

        public virtual DetailedSale DetailedSale { get; set; }

        [DisplayName("Usuario")]
        public string CreatedBy { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        [DisplayName("Fecha de Creacion")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [DisplayName("Fecha de Modificacion")]
        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }
    }
}