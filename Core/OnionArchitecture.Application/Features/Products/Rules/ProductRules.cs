using OnionArchitecture.Application.Bases;
using OnionArchitecture.Application.Features.Products.Exceptions;
using OnionArchitecture.Domain.Entites;

namespace OnionArchitecture.Application.Features.Products.Rules
{
    public class ProductRules:BaseRules
    {
        public Task ProductTileMustNotBeSame(IList<Product> products,string requestTitle)
        {
            if(products.Any(x=>x.Title==requestTitle)) throw new ProductTitleMustNotBeSameException();

            return Task.CompletedTask;
        }
    }
}
