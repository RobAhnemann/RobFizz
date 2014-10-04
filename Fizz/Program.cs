using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fizz.Business;

namespace Fizz
{
    class Program
    {
        static void Main(string[] args)
        {

            var fizzWriter = new Business.Fizz(new ConsoleWriter());

            var map = new List<IWriteMap>
            {
                new ModWriteMap(3, "Fizz"),
                new ModWriteMap(5, "Buzz")
            };

            fizzWriter.WriteFizz(100, map, new GenericWriteMap());

            Console.ReadLine();

        }
    }
}
