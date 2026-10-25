using System;

public class StudentRepository
{
	private readonly string _filePath = "students.txt";

	public void SaveStudent(Student student)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine($"{student.Id},{student.Name},{student.Age},{student.contactNumber},{student.Address},{student.Email},{student.Gender},{student.program},{student.department},{student.year_semester},{string.Join(";", student.Courses)}");
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
                    string[] parts = line.Split(',');
                    if (parts.Length >= 10)
                    {
                        int id = int.Parse(parts[0]);
                        string name = parts[1];
                        int age = int.Parse(parts[2]);
                        string contactNumber = parts[3];
                        string address = parts[4];
                        string email = parts[5];
                        string gender = parts[6];
                        string program = parts[7];
                        string department = parts[8];
                        string year_semester = parts[9];
                        List<string> courses = new List<string>();
                        if (parts.Length > 10)
                        {
                            courses.AddRange(parts[10].Split(';'));
                        }
                        Student student = new Student(id, name, age, contactNumber, address, email, gender, program, department, year_semester, courses);
                        students.Add(student);
                    }
                }
            }
        }
        return students;
    }

    public void ClearAllStudents()
    {
        File.WriteAllText(_filePath, string.Empty);
    }
}
