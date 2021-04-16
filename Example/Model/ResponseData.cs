using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Model
{
    public class ResponseData<T>
    {
        public bool IsSuccsess { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }
    }
    public class ResponseSingleData<T>
    {
        public bool IsSuccsess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
