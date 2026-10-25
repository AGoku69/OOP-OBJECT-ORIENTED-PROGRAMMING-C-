using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Area of a Square
            float lengthSQR;
            float areaSQR;
            Console.Write("Enter the length of the square: ");
            lengthSQR = float.Parse(Console.ReadLine());
            areaSQR = lengthSQR * lengthSQR;
            Console.WriteLine("The area of the square is: " + areaSQR);
            Console.ReadLine();

            // Area of a Rectangle
            float length, width, height;
            float volume;
            Console.Write("Enter the length: ");
            length = float.Parse(Console.ReadLine());
            Console.Write("Enter the width: ");
            width = float.Parse(Console.ReadLine());
            Console.Write("Enter the height: ");
            height = float.Parse(Console.ReadLine());
            volume = length * width * height;
            Console.WriteLine("The volume of the cuboid is: " + volume);
            Console.ReadLine();

            // Area of a Sphere
            float radius;
            float sphereVolume;
            Console.Write("Enter the radius of the sphere: ");
            radius = float.Parse(Console.ReadLine());
            sphereVolume = (4f / 3f) * (float)Math.PI * (float)Math.Pow(radius, 3);
            Console.WriteLine("The volume of the sphere is: " + sphereVolume);
            Console.ReadLine();

            // Area of a Triangle
            float baseLength, triangleHeight;
            float triangleArea;
            Console.Write("Enter the base length of the triangle: ");
            baseLength = float.Parse(Console.ReadLine());
            Console.Write("Enter the height of the triangle: ");
            triangleHeight = float.Parse(Console.ReadLine());
            triangleArea = 0.5f * baseLength * triangleHeight;
            Console.WriteLine("The area of the triangle is: " + triangleArea);
            Console.ReadLine();

            // Area of a Circle
            float radiusCircle;
            float circleArea;
            Console.Write("Enter the radius of the circle: ");
            radiusCircle = float.Parse(Console.ReadLine());
            circleArea = (float)Math.PI * (float)Math.Pow(radiusCircle, 2);
            Console.WriteLine("The area of the circle is: " + circleArea);
            Console.ReadLine();

        }
    }
}
