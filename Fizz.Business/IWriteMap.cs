namespace Fizz.Business
{
    public interface IWriteMap
    {
        bool Write(int value, IFizzWriter writer);
    }
}