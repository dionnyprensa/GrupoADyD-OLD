using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GrupoADyD.Models
{
    public class Client
    {
        [DisplayName("Id")]
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

        public virtual ICollection<Sale> Sales { get; set; }

        [DisplayName("Usuario")]
        public ApplicationUser UserName { get; set; }

        [DisplayName("Fecha de Creacion")]
        public DateTime CreationDate { get; set; }

        [DisplayName("Fecha de Modificacion")]
        public DateTime ModificationDate { get; set; }
    }
}