using OnionArchitecture.Application.Bases;

namespace OnionArchitecture.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException:BaseExceptions
    {
        public ProductTitleMustNotBeSameException(): base("Ürün başlığı zaten var") { }
    }
}
