using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace ConsoleApp1
{
    public static class ICollectionExtentions
    {
        public static void AddIssue<T>(this IList<T> issues)
            where T : Issue, new()
        {
            var element = new T();

            element.Fill();

            issues.Add(element);
        }

        public static void ShowAll<T>(this IList<T> issues)
            where T : Issue
        {
           foreach (var elem in issues)
                {
                    elem.Show();
                }                  
        }

        public static void ShowIssueById<T>(this IList<T> issues, long id)
            where T : Issue
        {
            try
            {
                var issue = issues.SingleOrDefault(x => x.Id == id);
                if (issue == null)
                {
                    throw new InvalidInputExceptions();
                }
                issue.Show();

                Console.ReadKey();

                Console.Clear();
            }
            catch (InvalidInputExceptions ex)
            {
                ex.ShowMessage();
            }          
        }

        public static  void SortIssues<T>(this IList<T> issues, string orderBy, int dest)
            where T : Issue
        {

            Console.Clear();
            if (orderBy == "Priority")

            {
                if (dest == 1)
                {
                   var result = issues.OrderBy(t => (int)t.Priority);
                    result.ToList().ShowAll();                                      
                }
                else if(dest == 2)
                {
                    var result = issues.OrderByDescending(t => (int)t.Priority);
                    result.ToList().ShowAll();
                }
            }
            else if(orderBy == "Status")
            {
                if (dest == 1)
                {
                    var result = issues.OrderBy(t => (int)t.Status);
                    result.ToList().ShowAll();
                }
                else if (dest == 2)
                {
                    var result = issues.OrderByDescending(t => (int)t.Status);
                    result.ToList().ShowAll();
                }
            }
        }

        public static void FilterIssues<T>(this ICollection<T> issues, string filterBy, string value)
        {

        }


        public static void  RunTestCaseById(this ICollection<TestCase> testCases, long id)
        {
            try
            {
                var issue = testCases.SingleOrDefault(x => x.Id == id);
                if (issue == null)
                {
                    throw new InvalidInputExceptions();
                }
                issue.Status = Status.InProgress;
                foreach(var step in issue.Steps)
                {
                    Console.Clear();
                    Console.WriteLine($"Is the expected and actual result consistent for Step {step.Number}?");
                    var choice = Actions.Choose("\n\nChoose an action:", "Yes", "No");
                    if (choice == 0)
                    {
                        continue;
                    }
                    else if (choice == 1)
                    {
                        var bug = new Bug();

                        var steps = "";
                        for (int i = 0; i < step.Number; i++)
                        {
                            steps += issue.Steps[i].Show();
                        }

                        bug.Fill(id, step.Number, step.Result, steps, issue.Precondition);

                        Application.bugs.Add(bug);

                        return;
                    }
                }
                issue.Status = Status.Done;               
            }
            catch (InvalidInputExceptions ex)
            {
                ex.ShowMessage();
            }
        }

        public static void ChangeBugStatusById(this ICollection<Bug> bugs, ICollection<TestCase> testCases, long id)
        {
            try
            {
                var bug = bugs.SingleOrDefault(x => x.Id == id);
                if (bug == null)
                {
                    throw new InvalidInputExceptions();
                }
                Console.Clear();
                Console.WriteLine("Choose new Status of bug");
                bug.Status = (Status)Actions.ChooseEnumOptions<Status>("Status");
                var testCaseFromBug = testCases.SingleOrDefault(x => x.Id == bug.TestCaseId);
                testCaseFromBug.Status = bug.Status;
                Console.Clear();
            }
            catch (InvalidInputExceptions ex)
            {
                ex.ShowMessage();
            }
        }

        public static void DeleteIssueById<T>(this IList<T> issues, long id)
            where T : Issue
        {
            try
            {
                var issue = issues.SingleOrDefault(x => x.Id == id);
                if (issue == null)
                {
                    throw new InvalidInputExceptions();
                }
                issues.RemoveAt(issues.IndexOf(issue));
            }
            catch (InvalidInputExceptions ex)
            {
                ex.ShowMessage();
            }
       }
        
    }
}
