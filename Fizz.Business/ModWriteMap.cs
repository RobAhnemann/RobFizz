namespace Fizz.Business
{
    public class ModWriteMap : IWriteMap
    {
        private int _modValue;
        private string _replaceWith;

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