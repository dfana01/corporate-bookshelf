using System;

namespace CorporateBookshelf.App
{
    internal class InvalidOptionHandle : IOptionHandle
    {
        bool IOptionHandle.Execute()
        {
            Console.WriteLine("Invalid option!");
            return true;
        }
    }
}