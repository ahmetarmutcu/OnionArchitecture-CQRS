using MediatR;
using OnionArchitecture.Application.Features.Products.Rules;
using OnionArchitecture.Application.Interfaces.UnitOfWorks;
using OnionArchitecture.Domain.Entites;

namespace OnionArchitecture.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommandRequest,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRules _productRules;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork,ProductRules productRules)
        {
            _unitOfWork = unitOfWork;
            _productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();

            //Kural oluşturuldu.
            await _productRules.ProductTileMustNotBeSame(products, request.Title);

            Product product = new(request.Title,request.Description,request.BrandId,request.Price,request.Discount);

            await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);

            if(await _unitOfWork.SaveAsync() > 0)
            {
                foreach(var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });
                }
                await _unitOfWork.SaveAsync();
            }
            return Unit.Value;
        }
    }
}
