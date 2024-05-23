namespace almacen.Models
{
    public class PageInfo
    {

        public int totalItems { get; set; }
        public int itemsPagina { get; set; }
        public int paginaActual { get; set; }
        public int totalPaginas => (int)Math.Ceiling((decimal)totalItems / itemsPagina);

    }
}
