using GrupoADyD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoADyD.ViewModels
{
    public class SaleViewModel
    {

        [DisplayName("# de Venta")]
        public ushort SalesNumber { get; set; }

        [DisplayName("Cliente")]
        public int ClientId { get; set; }

        public decimal Total { get; set; }

        public virtual Client Client { get; set; }

        [DisplayName("Descuento")]
        public decimal Discount { get; set; }

        [DisplayName("Costo")]
        public decimal Cost { get; set; }

        [DisplayName("Precio")]
        public decimal Price { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<Product> Products { get; set; }

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