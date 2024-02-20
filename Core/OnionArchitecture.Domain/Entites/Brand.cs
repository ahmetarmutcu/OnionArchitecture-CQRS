using OnionArchitecture.Domain.Common;

namespace OnionArchitecture.Domain.Entites
{
    public class Brand:EntityBase
    {
        public Brand()
        {
            
        }
        public Brand(string name)
        {
            Name = name;
        }
       public string Name { get; set; }
    }
}
