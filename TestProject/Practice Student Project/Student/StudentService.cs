using System;

public class StudentService
{
	private readonly StudentRepository _studentRepository;

	public StudentService()
	{
        _studentRepository = new StudentRepository();
    }

	public void AddStudent(Student student)
    {
        AlreadyExists(student);
        _studentRepository.SaveStudent(student);
    }

    public void AlreadyExists(Student student)
    {
        var Students = _studentRepository.GetAllStudents();
        foreach (var s in Students)
        {
            if (s.Id == student.Id || s.Email == student.Email)
            {
                Console.WriteLine("Student with the same Id or Email already exists.");
                return;
            }
        }
    }

    public void FindStudentById(int studentId)
    {
        var Students = _studentRepository.GetAllStudents();
        foreach (var student in Students)
        {
            if (student.Id == studentId)
            {
                Console.WriteLine(student.ToString());
                return;
            }
        }
        Console.WriteLine("Student not found.");
    }

    public void FindStudentByName(string studentName)
    {
        var Students = _studentRepository.GetAllStudents();
        foreach (var student in Students)
        {
            if (student.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(student.ToString());
                return;
            }
        }
        Console.WriteLine("Student not found.");
    }

    public void UpdateStudentAllDetails(int studentId, Student updatedStudent)
    {
        var Students = _studentRepository.GetAllStudents();
        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].Id == studentId)
            {
                Students[i] = updatedStudent;
                _studentRepository.SaveAllStudents(Students);
                return;
            }
        }
        Console.WriteLine("Student not found.");
    }

    public void DeleteStudentById(int studentId)
    {
        var Students = _studentRepository.GetAllStudents();
        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].Id == studentId)
            {
                Students.RemoveAt(i);
                _studentRepository.SaveAllStudents(Students);
                return;
            }
        }
        Console.WriteLine("Student not found.");
    }

    public void DeleteStudentByName(string studentName)
    {
        var Students = _studentRepository.GetAllStudents();
        for (int i = 0; i < Students.Count; i++)
        {
            if (Students[i].Name.Equals(studentName, StringComparison.OrdinalIgnoreCase))
            {
                Students.RemoveAt(i);
                _studentRepository.SaveAllStudents(Students);
                return;
            }
        }
        Console.WriteLine("Student not found.");
    }

    public Student GetStudentById(int studentId)
    {
        var Students = _studentRepository.GetAllStudents();
        foreach (var student in Students)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }
        Console.WriteLine("Student not found.");
        return null;
    }

    public Student GetStudentByName(string studentName)
    {
        var Students = _studentRepository.GetAllStudents();
        foreach (var student in Students)
        {
            if (student.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase))
            {
                return student;
            }
        }
        Console.WriteLine("Student not found.");
        return null;
    }

    public List<Student> GetAllStudents()
    {
        return _studentRepository.GetAllStudents();
    }

    public void ClearAllStudents()
    {
        _studentRepository.ClearAllStudents();
    }
}
