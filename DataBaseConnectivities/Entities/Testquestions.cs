

namespace DataBaseConnectivities.Entities
{
    /// <summary>
    /// Represents a test question linked to a subject.
    /// </summary>
    public class TestQuestion
    {
        public int Id { get; set; }                 // Primary key
        public string QuestionText { get; set; }    // The question text
        public int SubjectId { get; set; }          // Foreign key referencing Subject
    }
}
