using System;

public class StudentRepository
{
    private readonly string _filePath = "students.txt";

    public void SaveStudent(Student student)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine($"{student.Id},{student.Name},{student.Age}");
        }
    }
    public void SaveAllStudents(List<Student> students)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, false))
        {
            foreach (var student in students)
            {
                writer.WriteLine(student.ToString());
            }
        }
    }
    public List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();
        if (File.Exists(_filePath))
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        int age = int.Parse(parts[2]);
                        students.Add(new Student(id, name, age));
                    }
                }
            }
        }
        return students;
    }
}
