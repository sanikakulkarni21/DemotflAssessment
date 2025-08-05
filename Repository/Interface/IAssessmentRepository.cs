using System.Collections.Generic;
using DataBaseConnectivities.Entities;

namespace DataBaseConnectivities.Repository.Interfaces
{
    /// <summary>
    /// Contract for Assessment repository.
    /// Both ADO.NET and Dapper implementations will follow this.
    /// </summary>
    public interface IAssessmentRepository
    {
        void AddAssessment(Assessment assessment);     // Insert new assessment
        Assessment GetAssessmentById(int id);          // Fetch assessment by ID
        IEnumerable<Assessment> GetAllAssessments();   // Fetch all assessments
        void UpdateAssessment(Assessment assessment);  // Update assessment details
        void DeleteAssessment(int id);                // Delete assessment by ID
    }
}
