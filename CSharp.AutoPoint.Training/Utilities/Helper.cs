using System;

namespace CSharp.AutoPoint.Training.Utilities
{
    internal class Helper
    {
        internal string ReadInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        internal int ReadIntInput(string prompt)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return ReadIntInput(prompt);
        }
    }
}
