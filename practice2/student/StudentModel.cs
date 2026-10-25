using System;

public class Student
{
    public int id { get; set; }
    public string name { get; set; }
    public int age { get; set; }

    public Student() { }
     
    public Student(int id, string name, int age)
    {
        this.id = id;
        this.name = name;
        this.age = age;
    }
}
