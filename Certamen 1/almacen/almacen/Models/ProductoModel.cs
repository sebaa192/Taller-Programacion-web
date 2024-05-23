using almacen.ViewModel;

namespace almacen.Models
{
    public class ProductoModel
    {

        public List<ProductoListViewModel> productos { get; set; }
        public PageInfo pageInfo { get; set; }

        public string buscar { get; set; }
    }
}
