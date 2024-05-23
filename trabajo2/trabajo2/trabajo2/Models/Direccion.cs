namespace trabajo2.Models
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Direccion()
        {
            Cliente = new Cliente();
        }
    }
}
