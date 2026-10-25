namespace lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This program demonstrates the use of various data types in C# and how to read input from the console.
            // It prompts the user to enter values of different data types and then displays the entered values.
            // The program covers primitive types, nullable types, and some complex types like DateTime, TimeSpan, Guid, BigInteger, and Complex.
            // It also demonstrates the use of dynamic and object types.
            // The program uses Console.ReadLine() to read input from the user and parses the input to the appropriate data type.

            //  This one is used for integer input
            //  Exapmle : 5
            //  Note: int is a 32-bit signed integer
            Console.WriteLine("Enter an integer: ");
            int input = int.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + input);

            // This one is used for double input
            //  Example : 5.5
            //  Note: double can contain decimal values and is more precise than float
            Console.WriteLine("Enter a double: ");
            double inputDouble = double.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputDouble);

            // This one is used for string input
            //  Example : Hello World
            //  Note: string can contain spaces and special characters
            Console.WriteLine("Enter a string: ");
            string inputString = Console.ReadLine();
            Console.WriteLine("You entered: " + inputString);

            // This one is used for boolean input
            //  Example : true or false
            //  Note: boolean can only be true or false
            Console.WriteLine("Enter a boolean (true/false): ");
            bool inputBool = bool.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputBool);

            // This one is used for character input
            //  Example : A
            //  Note: char is a single character, not a string
            Console.WriteLine("Enter a character: ");
            char inputChar = char.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputChar);

            // This one is used for decimal input
            //  Example : 5.5
            //  Note: decimal has more precision than double and float
            Console.WriteLine("Enter a decimal: ");
            decimal inputDecimal = decimal.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputDecimal);

            // This one is used for float input
            //  Example : 5.5
            //  Note: float has less precision than double and decimal
            Console.WriteLine("Enter a float: ");
            float inputFloat = float.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputFloat);

            // This one is used for long input
            //  Example : 5000000000
            //  Note: long is a 64-bit signed integer
            Console.WriteLine("Enter a long: ");
            long inputLong = long.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputLong);

            // This one is used for short input
            //  Example : 5000
            //  Note: short is a 16-bit signed integer
            Console.WriteLine("Enter a short: ");
            short inputShort = short.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputShort);

            // This one is used for byte input
            //  Example : 255
            //  Note: byte is an 8-bit unsigned integer
            Console.WriteLine("Enter a byte: ");
            byte inputByte = byte.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputByte);

            // This one is used for sbyte input
            //  Example : -128
            //  Note: sbyte is an 8-bit signed integer
            Console.WriteLine("Enter a sbyte: ");
            sbyte inputSByte = sbyte.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputSByte);

            // This one is used for uint input
            //  Example : 5000000000
            //  Note: uint is a 32-bit unsigned integer
            Console.WriteLine("Enter a uint: ");
            uint inputUInt = uint.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputUInt);

            // This one is used for ulong input
            //  Example : 5000000000
            //  Note: ulong is a 64-bit unsigned integer
            Console.WriteLine("Enter a ulong: ");
            ulong inputULong = ulong.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputULong);

            // This one is used for ushort input
            //  Example : 50000
            //  Note: ushort is a 16-bit unsigned integer
            Console.WriteLine("Enter a ushort: ");
            ushort inputUShort = ushort.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputUShort);

            // This one is used for DateTime input
            //  Example : 2024-06-01
            //  Note: DateTime represents a date and time
            Console.WriteLine("Enter a DateTime (yyyy-MM-dd): ");
            DateTime inputDateTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputDateTime.ToString("yyyy-MM-dd"));

            // This one is used for TimeSpan input
            //  Example : 12:30:00
            //  Note: TimeSpan represents a time interval
            Console.WriteLine("Enter a TimeSpan (hh:mm:ss): ");
            TimeSpan inputTimeSpan = TimeSpan.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputTimeSpan.ToString(@"hh\:mm\:ss"));

            // This one is used for Guid input
            //  Example : 12345678-1234-1234-1234-123456789012
            //  Note: Guid is a globally unique identifier
            Console.WriteLine("Enter a Guid: ");
            Guid inputGuid = Guid.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputGuid.ToString());

            // This one is used for Uri input
            //  Example : https://www.example.com
            //  Note: Uri represents a Uniform Resource Identifier
            Console.WriteLine("Enter a Uri: ");
            Uri inputUri = new Uri(Console.ReadLine());
            Console.WriteLine("You entered: " + inputUri.ToString());

            // This one is used for BigInteger input
            //  Example : 123456789012345678901234567890
            //  Note: BigInteger can represent arbitrarily large integers
            Console.WriteLine("Enter a BigInteger: ");
            System.Numerics.BigInteger inputBigInteger = System.Numerics.BigInteger.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + inputBigInteger.ToString());

            // This one is used for Complex number input
            //  Example : 1.5, 2.5
            //  Note: Complex represents a complex number with real and imaginary parts
            Console.WriteLine("Enter a Complex number (real, imaginary): ");
            string complexInput = Console.ReadLine();
            double complexReal = 0, complexImag = 0;
            if (!string.IsNullOrWhiteSpace(complexInput))
            {
                var parts = complexInput.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    complexReal = double.Parse(parts[0].Trim());
                    complexImag = double.Parse(parts[1].Trim());
                }
            }
            System.Numerics.Complex inputComplex = new System.Numerics.Complex(complexReal, complexImag);
            Console.WriteLine("You entered: " + inputComplex.ToString());

            // This one is used for dynamic input
            // Example : any value
            // Note: dynamic allows for late binding and can hold any type of value
            Console.WriteLine("Enter a dynamic value: ");
            dynamic inputDynamic = Console.ReadLine();
            Console.WriteLine("You entered: " + inputDynamic.ToString());

            // This one is used for object input
            // Example : any value
            // Note: object is the base type for all types in C#
            Console.WriteLine("Enter an object: ");
            object inputObject = Console.ReadLine();
            Console.WriteLine("You entered: " + inputObject.ToString());

            // This one is used for nullable integer input
            // Example : 5 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable integer (or leave empty): ");
            string nullableInput = Console.ReadLine();
            int? inputNullableInt = string.IsNullOrEmpty(nullableInput) ? (int?)null : int.Parse(nullableInput);
            Console.WriteLine("You entered: " + (inputNullableInt.HasValue ? inputNullableInt.Value.ToString() : "null"));

            // This one is used for nullable double input
            // Example : 5.5 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable double (or leave empty): ");
            string nullableDoubleInput = Console.ReadLine();
            double? inputNullableDouble = string.IsNullOrEmpty(nullableDoubleInput) ? (double?)null : double.Parse(nullableDoubleInput);
            Console.WriteLine("You entered: " + (inputNullableDouble.HasValue ? inputNullableDouble.Value.ToString() : "null"));

            // This one is used for nullable boolean input
            // Example : true/false or leave empty for null
            // Note : nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable boolean (true/false or leave empty): ");
            string nullableBoolInput = Console.ReadLine();
            bool? inputNullableBool = string.IsNullOrEmpty(nullableBoolInput) ? (bool?)null : bool.Parse(nullableBoolInput);
            Console.WriteLine("You entered: " + (inputNullableBool.HasValue ? inputNullableBool.Value.ToString() : "null"));

            // This one is used for nullable DateTime input
            // Example : 2024-06-01 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable DateTime (yyyy-MM-dd or leave empty): ");
            string nullableDateTimeInput = Console.ReadLine();
            DateTime? inputNullableDateTime = string.IsNullOrEmpty(nullableDateTimeInput) ? (DateTime?)null : DateTime.Parse(nullableDateTimeInput);
            Console.WriteLine("You entered: " + (inputNullableDateTime.HasValue ? inputNullableDateTime.Value.ToString("yyyy-MM-dd") : "null"));

            // This one is used for nullable TimeSpan input
            // Example : 12:30:00 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable TimeSpan (hh:mm:ss or leave empty): ");
            string nullableTimeSpanInput = Console.ReadLine();
            TimeSpan? inputNullableTimeSpan = string.IsNullOrEmpty(nullableTimeSpanInput) ? (TimeSpan?)null : TimeSpan.Parse(nullableTimeSpanInput);
            Console.WriteLine("You entered: " + (inputNullableTimeSpan.HasValue ? inputNullableTimeSpan.Value.ToString(@"hh\:mm\:ss") : "null"));

            // This one is used for nullable Guid input
            // Example : 12345678-1234-1234-1234-123456789012 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable Guid (or leave empty): ");
            string nullableGuidInput = Console.ReadLine();
            Guid? inputNullableGuid = string.IsNullOrEmpty(nullableGuidInput) ? (Guid?)null : Guid.Parse(nullableGuidInput);
            Console.WriteLine("You entered: " + (inputNullableGuid.HasValue ? inputNullableGuid.Value.ToString() : "null"));

            // This one is used for nullable Uri input
            // Example : https://www.example.com or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable BigInteger (or leave empty): ");
            string nullableBigIntegerInput = Console.ReadLine();
            System.Numerics.BigInteger? inputNullableBigInteger = string.IsNullOrEmpty(nullableBigIntegerInput) ? (System.Numerics.BigInteger?)null : System.Numerics.BigInteger.Parse(nullableBigIntegerInput);
            Console.WriteLine("You entered: " + (inputNullableBigInteger.HasValue ? inputNullableBigInteger.Value.ToString() : "null"));

            // This one is used for nullable Complex number input
            // Example : 1.5, 2.5 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable Complex number (real, imaginary or leave empty): ");
            string nullableComplexInput = Console.ReadLine();
            System.Numerics.Complex? inputNullableComplex = null;
            if (!string.IsNullOrWhiteSpace(nullableComplexInput))
            {
                var parts = nullableComplexInput.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    double real = double.Parse(parts[0].Trim());
                    double imag = double.Parse(parts[1].Trim());
                    inputNullableComplex = new System.Numerics.Complex(real, imag);
                }
            }
            Console.WriteLine("You entered: " + (inputNullableComplex.HasValue ? inputNullableComplex.Value.ToString() : "null"));

            // This one is used for nullable dynamic input
            // Example : any value or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable dynamic value (or leave empty): ");
            string nullableDynamicInput = Console.ReadLine();
            dynamic inputNullableDynamic = string.IsNullOrEmpty(nullableDynamicInput) ? null : nullableDynamicInput;
            Console.WriteLine("You entered: " + (inputNullableDynamic != null ? inputNullableDynamic.ToString() : "null"));

            // This one is used for nullable object input
            // Example : any value or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable object (or leave empty): ");
            string nullableObjectInput = Console.ReadLine();
            object inputNullableObject = string.IsNullOrEmpty(nullableObjectInput) ? null : nullableObjectInput;
            Console.WriteLine("You entered: " + (inputNullableObject != null ? inputNullableObject.ToString() : "null"));

            // This one is used for nullable string input
            // Example : any value or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable string (or leave empty): ");
            string inputNullableString = Console.ReadLine();
            Console.WriteLine("You entered: " + (string.IsNullOrEmpty(inputNullableString) ? "null" : inputNullableString));

            // This one is used for nullable char input
            // Example : A or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable char (or leave empty): ");
            string nullableCharInput = Console.ReadLine();
            char? inputNullableChar = string.IsNullOrEmpty(nullableCharInput) ? (char?)null : char.Parse(nullableCharInput);
            Console.WriteLine("You entered: " + (inputNullableChar.HasValue ? inputNullableChar.Value.ToString() : "null"));

            // This one is used for nullable decimal input
            // Example : 5.5 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable decimal (or leave empty): ");
            string nullableDecimalInput = Console.ReadLine();
            decimal? inputNullableDecimal = string.IsNullOrEmpty(nullableDecimalInput) ? (decimal?)null : decimal.Parse(nullableDecimalInput);
            Console.WriteLine("You entered: " + (inputNullableDecimal.HasValue ? inputNullableDecimal.Value.ToString() : "null"));

            // This one is used for nullable float input
            // Example : 5.5 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable float (or leave empty): ");
            string nullableFloatInput = Console.ReadLine();
            float? inputNullableFloat = string.IsNullOrEmpty(nullableFloatInput) ? (float?)null : float.Parse(nullableFloatInput);
            Console.WriteLine("You entered: " + (inputNullableFloat.HasValue ? inputNullableFloat.Value.ToString() : "null"));

            // This one is used for nullable long input
            // Example : 5000000000 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable long (or leave empty): ");
            string nullableLongInput = Console.ReadLine();
            long? inputNullableLong = string.IsNullOrEmpty(nullableLongInput) ? (long?)null : long.Parse(nullableLongInput);
            Console.WriteLine("You entered: " + (inputNullableLong.HasValue ? inputNullableLong.Value.ToString() : "null"));

            // This one is used for nullable short input
            // Example : 5000 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable short (or leave empty): ");
            string nullableShortInput = Console.ReadLine();
            short? inputNullableShort = string.IsNullOrEmpty(nullableShortInput) ? (short?)null : short.Parse(nullableShortInput);
            Console.WriteLine("You entered: " + (inputNullableShort.HasValue ? inputNullableShort.Value.ToString() : "null"));

            // This one is used for nullable byte input
            // Example : 255 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable byte (or leave empty): ");
            string nullableByteInput = Console.ReadLine();
            byte? inputNullableByte = string.IsNullOrEmpty(nullableByteInput) ? (byte?)null : byte.Parse(nullableByteInput);
            Console.WriteLine("You entered: " + (inputNullableByte.HasValue ? inputNullableByte.Value.ToString() : "null"));

            // This one is used for nullable sbyte input
            // Example : -128 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable sbyte (or leave empty): ");
            string nullableSByteInput = Console.ReadLine();
            sbyte? inputNullableSByte = string.IsNullOrEmpty(nullableSByteInput) ? (sbyte?)null : sbyte.Parse(nullableSByteInput);
            Console.WriteLine("You entered: " + (inputNullableSByte.HasValue ? inputNullableSByte.Value.ToString() : "null"));

            // This one is used for nullable uint input
            // Example : 5000000000 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable uint (or leave empty): ");
            string nullableUIntInput = Console.ReadLine();
            uint? inputNullableUInt = string.IsNullOrEmpty(nullableUIntInput) ? (uint?)null : uint.Parse(nullableUIntInput);
            Console.WriteLine("You entered: " + (inputNullableUInt.HasValue ? inputNullableUInt.Value.ToString() : "null"));

            // This one is used for nullable ulong input
            // Example : 5000000000 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable ulong (or leave empty): ");
            string nullableULongInput = Console.ReadLine();
            ulong? inputNullableULong = string.IsNullOrEmpty(nullableULongInput) ? (ulong?)null : ulong.Parse(nullableULongInput);
            Console.WriteLine("You entered: " + (inputNullableULong.HasValue ? inputNullableULong.Value.ToString() : "null"));

            // This one is used for nullable ushort input
            // Example : 50000 or leave empty for null
            // Note: nullable types can hold a value or be null
            Console.WriteLine("Enter a nullable ushort (or leave empty): ");
            string nullableUShortInput = Console.ReadLine();
            ushort? inputNullableUShort = string.IsNullOrEmpty(nullableUShortInput) ? (ushort?)null : ushort.Parse(nullableUShortInput);
            Console.WriteLine("You entered: " + (inputNullableUShort.HasValue ? inputNullableUShort.Value.ToString() : "null"));


            Console.WriteLine("All inputs have been processed.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
