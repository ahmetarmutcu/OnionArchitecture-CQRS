using OnionArchitecture.Domain.Common;

namespace OnionArchitecture.Domain.Entites
{
    public class ProductCategory:IEntityBase
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
