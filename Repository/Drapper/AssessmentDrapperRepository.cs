using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using DataBaseConnectivities.Entities;
using DataBaseConnectivities.Repository.Interfaces;

namespace DataBaseConnectivities.Repository.Dapper
{
    /// <summary>
    /// Implementation of IAssessmentRepository using Dapper ORM.
    /// Dapper simplifies SQL mapping with less code.
    /// </summary>
    public class AssessmentDapperRepository : IAssessmentRepository
    {
        private readonly string _connectionString;

        public AssessmentDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAssessment(Assessment assessment)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute("INSERT INTO Assessments (Name, Date) VALUES (@Name, @Date)", assessment);
            }
        }

        public Assessment GetAssessmentById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.QuerySingleOrDefault<Assessment>(
                    "SELECT Id, Name, Date FROM Assessments WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Assessment> GetAllAssessments()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Assessment>("SELECT Id, Name, Date FROM Assessments");
            }
        }

        public void UpdateAssessment(Assessment assessment)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute("UPDATE Assessments SET Name = @Name, Date = @Date WHERE Id = @Id", assessment);
            }
        }

        public void DeleteAssessment(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute("DELETE FROM Assessments WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
