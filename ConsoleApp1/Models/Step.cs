using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Step
    {
        public static int numberCounter = 1;
        public int Number { get;}
        public string Action { get; set; }
        public string Result { get; set; }
       
        public Step()
        {
            Number = numberCounter++;

        }

        public string Show()
        {        
            return 
                string.Concat ($"\tStep Number:{Number} " ,
                $"\n\t\tAction {Action} " ,
                $"\n\t\tResult:{Result} \n\n");
        }

        public void Set()
        {
            while (true)
            {
                Console.WriteLine("Enter Action:");
                string tempAction = Console.ReadLine();
                if (tempAction != "")
                {
                    this.Action = tempAction;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect Action\n");
                }
            }
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Enter Result:");

                string tempResult = Console.ReadLine();
                if (tempResult != "")
                {
                    this.Result = tempResult;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect Result\n");
                }
            }
            Console.Clear();
        }
    }
}
