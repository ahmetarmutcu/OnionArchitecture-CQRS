using MediatR;
using OnionArchitecture.Application.Interfaces.RedisCache;

namespace OnionArchitecture.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQueryRequest:IRequest<IList<GetAllBrandsQueryResponse>>,ICacheableQuery
    {
        public string CacheKey => "GetAllBrands";

        public double CacheTime => 5;
    }
}
