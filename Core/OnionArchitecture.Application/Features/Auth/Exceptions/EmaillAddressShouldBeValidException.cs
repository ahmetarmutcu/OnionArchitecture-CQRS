using OnionArchitecture.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Features.Auth.Exceptions
{
    public class EmaillAddressShouldBeValidException : BaseException
    {
        public EmaillAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır.") { }
    }
}
