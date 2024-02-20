namespace OnionArchitecture.Domain.Common
{
    public class EntityBase:IEntityBase
    {
        public required int Id { get; set; }
        public required DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public required  bool IsDeleted=false;
    }
}
