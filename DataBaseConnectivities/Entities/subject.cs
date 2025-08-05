

namespace DataBaseConnectivities.Entities
{
    /// <summary>
    /// Represents a subject (e.g., Java, C#, SQL).
    /// </summary>
    public class Subject
    {
        public int Id { get; set; }           // Primary key
        public string Title { get; set; }     // Subject name
    }
}
