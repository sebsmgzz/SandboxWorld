using System;

namespace CSharpEnumAsString
{
    public static class Program
    {

        public static void Main(string[] args)
        {

            var color = Color.Blue;
            Console.WriteLine(color.ToString());
            Console.WriteLine(Enum.GetName(typeof(Color), color));

        }

    }
}
