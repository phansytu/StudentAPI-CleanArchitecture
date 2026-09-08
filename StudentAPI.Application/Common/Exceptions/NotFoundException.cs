using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StudentAPI.Application.Common.Exceptions
{

    public class NotFoundException : Exception
    {
        public NotFoundException(string mess) : base(mess) { }

    }

}