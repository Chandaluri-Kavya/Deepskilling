public class StudentView
{
    public void DisplayStudent(string name, string rollNo)
    {
        Console.WriteLine("Student Details");
        Console.WriteLine($"Name    : {name}");
        Console.WriteLine($"Roll No : {rollNo}");
    }
}