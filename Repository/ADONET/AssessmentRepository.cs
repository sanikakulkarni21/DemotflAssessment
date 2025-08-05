using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataBaseConnectivities.Entities;
using DataBaseConnectivities.Repository.Interfaces;

namespace DataBaseConnectivities.Repository.ADONET
{
    /// <summary>
    /// Implementation of IAssessmentRepository using ADO.NET.
    /// This uses SqlConnection and SqlCommand for database operations.
    /// </summary>
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly string _connectionString;

        public AssessmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddAssessment(Assessment assessment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Assessments (Name, Date) VALUES (@Name, @Date)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", assessment.Name);
                cmd.Parameters.AddWithValue("@Date", assessment.Date);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Assessment GetAssessmentById(int id)
        {
            Assessment assessment = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Name, Date FROM Assessments WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    assessment = new Assessment
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Date = (DateTime)reader["Date"]
                    };
                }
            }
            return assessment;
        }

        public IEnumerable<Assessment> GetAllAssessments()
        {
            var assessments = new List<Assessment>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, Name, Date FROM Assessments";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    assessments.Add(new Assessment
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Date = (DateTime)reader["Date"]
                    });
                }
            }
            return assessments;
        }

        public void UpdateAssessment(Assessment assessment)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Assessments SET Name = @Name, Date = @Date WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", assessment.Name);
                cmd.Parameters.AddWithValue("@Date", assessment.Date);
                cmd.Parameters.AddWithValue("@Id", assessment.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAssessment(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Assessments WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
