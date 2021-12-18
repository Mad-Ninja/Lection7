using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IIssue
    {

        public long Id { get; }
        public DateTime CreationDate{ get; }
        public Priority Priority { get; set; }
        public string Summary { get; set; }
        public string Precondition { get; set; }
        public Status Status { get; set; }

        public void Fill();
        public void Show();
    }
}
