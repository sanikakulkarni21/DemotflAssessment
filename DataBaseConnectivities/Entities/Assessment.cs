

namespace DataBaseConnectivities.Entities
{
    /// <summary>
    /// Represents the Assessments table in the database.
    /// </summary>
    public class Assessment
    {
        public int Id { get; set; }       // Primary key
        public string Name { get; set; }  // Name of the assessment
        public DateTime Date { get; set; } // Date of the assessment
    }
}
