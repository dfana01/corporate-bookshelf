namespace CorporateBookshelf.App
{
    internal class ExitHandle : IOptionHandle
    {
        bool IOptionHandle.Execute()
        {
            return false;
        }
    }
}