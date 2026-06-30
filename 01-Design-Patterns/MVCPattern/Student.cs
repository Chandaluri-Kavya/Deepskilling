public class Student
{
    public string Name { get; set; }
    public string RollNo { get; set; }

    public Student(string name, string rollNo)
    {
        Name = name;
        RollNo = rollNo;
    }
}