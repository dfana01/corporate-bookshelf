namespace CorporateBookShelf.Models
{
    /// <summary>
    /// Represents job description.
    /// </summary>
    public class Job
    {    
        public Job()
        {
        }

        /// <summary>
        /// Job name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// job id
        /// </summary>
        public int Id { get; set; }
    }
}