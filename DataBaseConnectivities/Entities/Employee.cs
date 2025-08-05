namespace DataBaseConnectivities.Entities
{
    /// <summary>
    /// Represents the Employees table in the database.
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }          // Primary key
        public string Name { get; set; }     // Employee name
        public string Department { get; set; } // Department name
    }
}
