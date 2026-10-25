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
            if (s.Id == student.Id || s.age == student.age)
            {
                Console.WriteLine("Student with the same Id or Age already exists.");
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