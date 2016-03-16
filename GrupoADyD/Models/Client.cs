using System;
using System.Collections.Generic;

namespace GrupoADyD.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal Discount { get; set; }
        public bool ToCost { get; set; }
        public string Direction { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }

        public ApplicationUser Usuario { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}