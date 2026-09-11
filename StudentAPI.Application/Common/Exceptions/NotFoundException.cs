using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace StudentAPI.Application.Common.Exceptions
{

    public class NotFoundException : Exception
    {
        public NotFoundException(string mess) : base(mess) { }
        public NotFoundException(string name, object key)
        : base($"Không tìm thấy đối tượng \"{name}\" với khóa ({key}).") { }

    }

}