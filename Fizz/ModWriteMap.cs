using Fizz.Business;

namespace Fizz
{
    public class ModWriteMap : IWriteMap
    {
        private readonly int _modValue;
        private readonly string _replaceWith;

        public ModWriteMap(int modValue, string replaceWith)
        {
            _modValue = modValue;
            _replaceWith = replaceWith;
        }

        public bool Write(int value, IFizzWriter writer)
        {
            if (value%_modValue == 0)
            {
                writer.Write(_replaceWith);
                return true;
            }

            return false;

        }
    }
}