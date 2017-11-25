using System;

namespace CorporateBookshelf.App
{
    internal class InvalidOptionHandle : IOptionHandle
    {
        public bool Execute()
        {
            Console.WriteLine("Invalid option!");
            return true;
        }
    }
}