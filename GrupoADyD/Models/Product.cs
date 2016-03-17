using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoADyD.Models
{
    public class Product
    {
        [DisplayName("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [DisplayName("Codigo")]
        public string Code { get; set; }

        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Descripcion")]
        public string Description { get; set; }

        [DisplayName("PV")]
        public decimal PV { get; set; }

        [DisplayName("BV")]
        public decimal BV { get; set; }

        [DisplayName("Cost")]
        public decimal Cost { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("BestSeller")]
        public int BestSeller { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<DetailedSale> DetailedSales { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

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