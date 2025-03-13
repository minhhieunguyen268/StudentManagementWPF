using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Response<T>
    {
        public T? Value { get; set; }

        public bool IsSuccess { get; set; }

    }
}
