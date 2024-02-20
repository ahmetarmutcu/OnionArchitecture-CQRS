using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entites;

namespace OnionArchitecture.Persistence.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("tr");
            Product product = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10,1000),
                CreatedDateTime=DateTime.Now,
                IsDeleted=true
            };
            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3,
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                CreatedDateTime = DateTime.Now,
                IsDeleted = true
            };
            builder.HasData(product, product2);
        }
    }
}
