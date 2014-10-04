using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizz.Business
{
    public interface IFizzWriter
    {
        void Write(string text);
        
        void NewLine();
    }
}
