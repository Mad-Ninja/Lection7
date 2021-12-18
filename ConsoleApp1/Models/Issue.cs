using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ConsoleApp1
{
    public abstract class Issue : IIssue
    {
        private static int idCounter;

        public long Id { get;}

        public DateTime CreationDate { get; set; }

        public Priority Priority { get; set; }

        public string Summary { get; set; }

        public string Precondition { get; set; }

        public Status Status { get; set; }

        public Issue()
        {
            Id = idCounter++;
            CreationDate = DateTime.Now;
            Status = Status.New;
            

        }

        public virtual void Show()
        {
            Console.WriteLine(string.Concat($"Id: {Id}",
               $"\nCreation date: {CreationDate}",
               $"\nPriority: {Priority}",
               $"\nSummarry: {Summary}",
               $"\nPrecondition: {Precondition}",
               $"\nStatus: {Status}"));
        }

        public virtual void Fill()
        {
            CreationDate = DateTime.Now;
            this.Priority = (Priority)Actions.ChooseEnumOptions<Priority>("Priority");
            Console.Clear();
  
        }
    }
}
