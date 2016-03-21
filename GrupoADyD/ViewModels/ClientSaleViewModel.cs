using System.ComponentModel;

namespace GrupoADyD.ViewModels
{
    public class ClientSaleViewModel
    {
        [DisplayName("Nombre")]
        public string FullName { get; set; }

        [DisplayName("Descuento")]
        public decimal Discount { get; set; }

        [DisplayName("A Costo")]
        public bool ToCost { get; set; }
    }
}