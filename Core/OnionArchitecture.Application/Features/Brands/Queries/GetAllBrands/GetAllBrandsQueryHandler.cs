using MediatR;
using Microsoft.AspNetCore.Http;
using OnionArchitecture.Application.Bases;
using OnionArchitecture.Application.Interfaces.AutoMapper;
using OnionArchitecture.Application.Interfaces.UnitOfWorks;
using OnionArchitecture.Domain.Entites;

namespace OnionArchitecture.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryHandler : BaseHandler, IRequestHandler<GetAllBrandsQueryRequest, IList<GetAllBrandsQueryResponse>>
    {
        public GetAllBrandsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var brands = await _unitOfWork.GetReadRepository<Brand>().GetAllAsync();

            return _mapper.Map<GetAllBrandsQueryResponse, Brand>(brands);
        }
    }
}
