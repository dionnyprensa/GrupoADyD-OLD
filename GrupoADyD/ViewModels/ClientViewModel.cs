using System.ComponentModel;

namespace GrupoADyD.ViewModels
{
    public class ClientViewModel
    {
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
    }
}