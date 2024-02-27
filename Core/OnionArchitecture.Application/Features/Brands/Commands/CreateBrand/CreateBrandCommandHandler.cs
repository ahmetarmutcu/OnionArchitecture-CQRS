using Bogus;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnionArchitecture.Application.Bases;
using OnionArchitecture.Application.Interfaces.AutoMapper;
using OnionArchitecture.Application.Interfaces.UnitOfWorks;
using OnionArchitecture.Domain.Entites;

namespace OnionArchitecture.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler:BaseHandler,IRequestHandler<CreateBrandCommandRequest,Unit>
    {
        public CreateBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<Unit> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            Faker faker = new("tr");
            List<Brand> brand = new();
            for(int i=0;i<1000000;i++)
            {
                brand.Add(new(faker.Commerce.Department(1)));
            }

            await _unitOfWork.GetWriteRepository<Brand>().AddRangeAsync(brand);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
