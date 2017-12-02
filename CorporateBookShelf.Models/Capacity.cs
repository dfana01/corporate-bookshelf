namespace CorporateBookShelf.Models
{
    /// <summary>
    /// Capacity entity
    /// </summary>
    public class Capacity
    {
        /// <summary>
        /// Capacity Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Capacity name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Job related to this capacity
        /// </summary>
        public Job Job { get; set; }
    }
}