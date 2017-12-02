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
            switch (option)
            {
                case "1": return new AddJobHandle();
                case "2": return new AddBookHandle();
                case "3": return new AddCollaboratorHandle();
                case "0": return new ExitHandle();
                default: return new InvalidOptionHandle();
            }
        }
    }

}
