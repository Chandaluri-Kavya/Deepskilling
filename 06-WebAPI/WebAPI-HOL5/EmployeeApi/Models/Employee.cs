namespace EmployeeApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public double Salary { get; set; }

        public bool Permanent { get; set; }

        public Department? Department { get; set; }

        public List<Skill>? Skills { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}