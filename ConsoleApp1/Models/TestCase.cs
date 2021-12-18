using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestCase : Issue
    {
        public List<Step> Steps { get; set; } 
        
        public TestCase() : base()
        {
            Steps = new List<Step>();
        }

        public override void Show()
        {
            var steps = "";

                 for (int i = 0; i < Steps.Count; i++)
            {

               steps += Steps[i].Show();

            }

            base.Show();

            Console.WriteLine(string.Concat($"Steps:\n{steps}\n\n\n"));
        }

        public override void Fill()
        {
            Step.numberCounter = 1;
            base.Fill();


            while (true)
            {
                Console.WriteLine("Enter summary:");
                string tempSum = Console.ReadLine();
                if (tempSum != "")
                {
                    Summary = tempSum;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect summary\n");
                }
            }
            Console.Clear();
            while (true)
            {

                Console.WriteLine("Enter precondition:");
                string tempPrec = Console.ReadLine();
                if (tempPrec != "")
                {
                    Precondition = tempPrec;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect precondition\n");
                }
            }
            Console.Clear();
            this.Status = (Status)Actions.ChooseEnumOptions<Status>("Status");
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Add step?(1 - Yes, 2 - No):");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    if (value == 1)
                    {
                        Step step = new Step();
                        step.Set();
                        Steps.Add(step);

                    }
                    if (value == 2) { break; }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input\n");
                }
            }
            Console.Clear();
        }






















        




    }
}
