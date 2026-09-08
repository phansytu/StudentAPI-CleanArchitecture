using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StudentAPI.Application.Common.Exceptions
{
    public class BoMonException : Exception
    {
        public class BoMonBadRequestException : NotFoundException
        {
            public BoMonBadRequestException(string message) : base(message) { }
        }
        public class BoMonNotFoundException : BadRequestException
        {
            public BoMonNotFoundException(string mess) : base(mess) { }

        }
    }
}