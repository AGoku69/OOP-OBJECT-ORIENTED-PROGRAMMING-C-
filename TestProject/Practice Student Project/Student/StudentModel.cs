using System;

public class Student
{
	public int Id { get; set; }
	public string Name { get; set; }
	public int Age { get; set; }
	public string contactNumber { get; set; }
	public string Address { get; set; }
	public string Email { get; set; }
	public string Gender { get; set; }
	public string program { get; set; }
	public string department { get; set; }
	public string year_semester { get; set; }
	public List<string> Courses { get; set; }
	
	public Student() { }

	public Student(int id, string name, int age, string contactNumber, string address, string email, string gender, string program, string department, string year_semester, List<string> courses)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
        this.contactNumber = contactNumber;
        this.Address = address;
        this.Email = email;
        this.Gender = gender;
        this.program = program;
        this.department = department;
        this.year_semester = year_semester;
        this.Courses = courses;
    }
	public override TOstring()
	{
		return $"Id: {Id}, Name: {Name}, Age: {Age}, Contact Number: {contactNumber}, Address: {Address}, Email: {Email}, Gender: {Gender}, Program: {program}, Department: {department}, Year/Semester: {year_semester}, Courses: {string.Join(", ", Courses)}";
    }
}