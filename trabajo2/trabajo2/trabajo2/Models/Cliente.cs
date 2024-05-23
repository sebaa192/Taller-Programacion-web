using System.Diagnostics.Contracts;

namespace trabajo2.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public List<Contacto> Contactos { get; set; }
        public Cliente()
        {
                Direcciones = new List<Direccion>();
              Contactos = new List<Contacto>();
        }
    }
}
