using System.ComponentModel.DataAnnotations;

namespace almacen.ViewModel
{
    public class ProductoListViewModel
    {
   
        public int id { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public string imagen { get; set; }
        public int idCategoria { get; set; }
        public string NombreCategoria { get; set; }
    }
}
