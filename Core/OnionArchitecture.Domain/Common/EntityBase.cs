namespace OnionArchitecture.Domain.Common
{
    public class EntityBase:IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }
    }
}
