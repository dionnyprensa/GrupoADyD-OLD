using System.ComponentModel;

namespace GrupoADyD.ViewModels
{
    public class ProductViewModel
    {
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

        [DisplayName("Costo IBO")]
        public decimal Cost { get; set; }

        [DisplayName("Precio")]
        public decimal Price { get; set; }
    }
}