using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Entites;

namespace OnionArchitecture.Persistence.Configurations
{
    internal class DetailConfiguration:IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("tr");
            Detail detail = new()
            {
                Id = 1,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,
                CreatedDateTime = DateTime.Now,
                IsDeleted = false
            };
            Detail detail2 = new()
            {
                Id = 2,
                Title = faker.Lorem.Sentence(2),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3,
                CreatedDateTime = DateTime.Now,
                IsDeleted = true
            };
            Detail detail3 = new()
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                CreatedDateTime = DateTime.Now,
                IsDeleted = false
            };
            builder.HasData(detail, detail2, detail3);
        }
    }
}
