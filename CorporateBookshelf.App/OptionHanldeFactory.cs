using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateBookshelf.App
{
    public static class OptionHanldeFactory
    {
        public static IOptionHandle Create(string option)
        {
            if (option == "1")
            {
                return new AddJobHandle();
            }
            else if (option == "0")
            {
                return new ExitHandle();
            }
            
            return new InvalidOptionHandle();
        }
    }
}
