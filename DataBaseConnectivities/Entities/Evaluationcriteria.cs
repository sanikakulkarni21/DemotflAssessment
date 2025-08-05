namespace DataBaseConnectivities.Entities
{
    /// <summary>
    /// Represents criteria for evaluating assessments.
    /// </summary>
    public class EvaluationCriteria
    {
        public int Id { get; set; }            // Primary key
        public string CriteriaName { get; set; } // Name of the criteria
        public int Weightage { get; set; }     // Weight of the criteria in scoring
    }
}
