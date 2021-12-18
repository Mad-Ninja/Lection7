using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class InvalidInputExceptions : Exception
    {
        public InvalidInputExceptions() : base("Invalid input. Try again.\n")
        {
        }
        public void ShowMessage()
        {
            Console.Clear();
            Console.WriteLine(Message);
            Console.ReadKey();
        }

        public InvalidInputExceptions(string message) : base(message)
        {
        }
    }
}
