using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoADyD.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        [DisplayName("Nombre")]
        public string FirstName { get; set; }

        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [DisplayName("Telefono")]
        public string Phone { get; set; }

        [DisplayName("Descuento")]
        public decimal Discount { get; set; }

        [DisplayName("A Costo")]
        public bool ToCost { get; set; }

        [DisplayName("Direccion")]
        public string Direction { get; set; }

        [DisplayName("Usuario")]
        public string CreatedBy { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        //public virtual ICollection<Sale> Sales { get; set; }

        [DisplayName("Fecha de Creacion")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [DisplayName("Fecha de Modificacion")]
        [DataType(DataType.DateTime)]
        public DateTime ModificationDate { get; set; }
    }
}