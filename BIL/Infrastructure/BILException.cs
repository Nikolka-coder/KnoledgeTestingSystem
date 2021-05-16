using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infrastructure
{
    public class BILException : Exception
    {
        public string Property { get; protected set; }
        public BILException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
