using System;
using Fizz.Business;

namespace Fizz
{
    public class ConsoleWriter: IFizzWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void NewLine()
        {
            Console.Write("\r\n");
        }
    }
}
