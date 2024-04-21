using System.ComponentModel.DataAnnotations;

namespace almacen.Models
{
    public class Producto
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name ="Nombre Producto")]
        public string nombre { get; set; }
        [Required]
        public int precio { get; set; }
        public string imagen { get; set; }
        public int idCategoria { get; set; }
    }
}
