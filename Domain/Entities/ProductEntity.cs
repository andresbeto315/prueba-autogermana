using Domain.Base;

namespace Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public int idproducto { get; set; }
        public int idcategoria { get; set; }
        public CategoryEntity category { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public double precio_venta { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public object imagen { get; set; }
        public bool estado { get; set; }
    }
}