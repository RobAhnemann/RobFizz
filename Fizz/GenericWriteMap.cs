using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fizz.Business;

namespace Fizz
{
    public class GenericWriteMap : IWriteMap
    {
        public bool Write(int value, IFizzWriter writer)
        {
            writer.Write(value.ToString());
            return true;
        }
    }
}
