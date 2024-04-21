using System.ComponentModel.DataAnnotations;

namespace almacen.Models
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public int celular { get; set; }
    }
}
