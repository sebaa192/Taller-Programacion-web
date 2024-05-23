namespace trabajo2.Models
{
    public class Contacto
    {
        public int ContactoId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Contacto()
        {
            Cliente= new Cliente();
        }
    }
}
