using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateBookshelf.App
{
    /// <summary>
    /// Responsible to create menu option handles.
    /// </summary>
    public static class OptionHandleFactory
    {
        /// <summary>
        /// return the specific implementation of handle.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
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
