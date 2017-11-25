using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateBookshelf.App
{
    /// <summary>
    /// Handle the menu's option execution
    /// </summary>
    public interface IOptionHandle
    {
        /// <summary>
        /// Execute the option and return true if will continue, false if not
        /// </summary>
        /// <returns></returns>
        bool Execute();
    }
}
