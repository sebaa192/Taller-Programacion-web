using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace almacen.ViewModel
{
    public class ProductoViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre Producto")]
        public string nombre { get; set; }
        [Required]
        public int precio { get; set; }
        public string imagen { get; set; }
        public int idCategoria { get; set; }
        public IEnumerable<SelectListItem> Categorias { get; set; } = default!;
    }
}
