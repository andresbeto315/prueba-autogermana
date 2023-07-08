using Domain.Base;

namespace Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public int idcategoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set;}
        public bool estado { get; set; }
    }
}