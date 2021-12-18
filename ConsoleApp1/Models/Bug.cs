using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1

{
    public class Bug : Issue
    {
        
        public long? TestCaseId  { get; set; }
        public int? StepNumber { get; set; }
        public string ActualResult { get; set; }
        public string ExpectedResult { get; set; }

        public Bug() : base()
        {
            
        }

       public override void Show()
        {
            base.Show();
            Console.WriteLine( string.Concat(
                $"Test Case Id: {TestCaseId}",
                $"\nStep Number: {StepNumber}",
                $"\nActual Result: {ActualResult}",
                $"\nExpected Result: {ExpectedResult}\n\n\n"));
        }

        public  void Fill(long id, int stNumber, string stepResult, string steps, string TcPrec)
        {

            TestCaseId = id;
            StepNumber = stNumber;
            Summary = $"{stepResult} doesn't work";
            Precondition = $"{TcPrec}\n {steps}";
            ExpectedResult = stepResult;

            Console.Clear();
            while (true)
            {
                Console.WriteLine("Enter Actual Result:");
                string tempAcRes = Console.ReadLine();
                if (tempAcRes != "")
                {
                    ActualResult = tempAcRes;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect Actual Result\n");
                }                           
            }
            Console.Clear();

            base.Fill();

            Console.Clear();
        }






        











    }
}
