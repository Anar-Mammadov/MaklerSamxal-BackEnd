using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "educative";

            if (str.Length == 0)
                System.Console.WriteLine("Empty String");
            else if (str.Length == 1)
                System.Console.WriteLine(char.ToUpper(str[0]));
            else
                System.Console.WriteLine(char.ToUpper(str[0]) + str.Substring(1));
        }
    }
}
