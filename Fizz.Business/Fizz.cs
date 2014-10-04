using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizz.Business
{
    public class Fizz
    {
        private readonly IFizzWriter _writer;

        public Fizz(IFizzWriter writer)
        {
            _writer = writer;
        }

        public void WriteFizz(int upperLimit, List<IWriteMap> maps, IWriteMap genericMap)
        {
            //Check for args
            if (maps == null || maps.Count == 0)
                throw new ArgumentException("Invalid Maps!");

            if (genericMap == null)
                throw new ArgumentException("No Generic Map specified");

            if (upperLimit < 0)
                throw new ArgumentException("invalid upper limit");

            for (int i = 1; i <= upperLimit; i++)
            {
                bool isHandled = false;

                foreach (var map in maps)
                {
                    //Track whether or not the generic needs to do work
                    isHandled  = isHandled | map.Write(i, _writer);
                }

                //If we've not handled the loop, then we need the generic to do work
                if (!isHandled)
                    genericMap.Write(i, _writer);

                _writer.NewLine();
            }
        }
    }
}
