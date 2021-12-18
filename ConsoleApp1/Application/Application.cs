using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Application
    {
        public static List<Bug> bugs = new List<Bug>();
        public static List<TestCase> testCases = new List<TestCase>();

        public void Run()
        {
            while (true)
            {               
                var choice = Actions.Choose("\n\nCHOOSE AN ACTION:\n",
                        "Create a test case",
                        "Show a test case by id",
                        "Show all test cases",
                        "Delete test case by id",
                        "Run a test case by id",
                        "Show a bug by id",
                        "Show all bugs",
                        "Change a bug status by id",
                        "Delete a bug",
                        "Exit"
                        );

                switch (choice)
                {
                    case 0:
                        Console.Clear();

                        testCases.AddIssue();

                        break;
                    case 1:
                        Console.Clear();
                        if (testCases.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"No Test Cases\n");                           
                        }
                        else
                        {
                            Console.WriteLine($"Enter Test Case ID");
                            if (int.TryParse(Console.ReadLine(), out var elemId))
                            {
                                testCases.ShowIssueById(elemId);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Incorrect element ID\n");
                            }
                        }                       
                        break;
                    case 2:
                        Console.Clear();
                        if (testCases.Count == 0)
                        {
                            Console.WriteLine($"No Test Cases\n");
                        }
                        else
                        {
                            Console.WriteLine($"\n\tTEST CASES:\n");
                            testCases.ShowAll();
                        }
                                              
                        while (testCases.Count != 0)
                        {
                            var choice1 = Actions.Choose("\n\nCHOOSE AN ACTION:","Sort elements", "Filter elements", "Exit");
                            if (choice1 == 0)
                            {
                                Console.Clear();
                                var choice1_1 = Actions.Choose("CHOOSE AN ACTION:\n","Sort by Priority", "Sort by Status");
                                if (choice1_1 == 0)
                                {
                                    Console.Clear();
                                    var choice1_1_1 = Actions.Choose("CHOOSE AN ACTION:\n", "Ascending priority", "Descending priority");
                                    if(choice1_1_1 == 0)
                                    {
                                        testCases.SortIssues("Priority", 1);
                                    }
                                    else if(choice1_1_1 == 1)
                                    {
                                        testCases.SortIssues("Priority", 2);
                                    }
                                }
                                else if (choice1_1 == 1)
                                {
                                    Console.Clear();
                                    var choice1_1_2 = Actions.Choose("CHOOSE AN ACTION:\n", "Ascending status", "Descending status");
                                    if (choice1_1_2 == 0)
                                    {
                                        testCases.SortIssues("Status", 1);
                                    }
                                    else if (choice1_1_2 == 1)
                                    {
                                        testCases.SortIssues("Status", 2);
                                    }
                                }
                            }
                            else if (choice1 == 1)
                            {
                                Console.Clear();
                                var choice1_2 = Actions.Choose("CHOOSE AN ACTION:\n", "Filter by Priority", "Filter by Status", "Filter by Summary");
                                if (choice1_2 == 0)
                                {
                                    Console.Clear();
                                    var choice1_2_2 = Actions.Choose("\n\nChoose priority:", "Low", "Medium", "High", "Critical");
                                    if(choice1_2_2 == 0)
                                    {
                                        testCases.FilterIssues("Priority", "Low");
                                    }
                                    else if(choice1_2_2 == 1)
                                    {
                                        testCases.FilterIssues("Priority", "Medium");
                                    }
                                    else if (choice1_2_2 == 2)
                                    {
                                        testCases.FilterIssues("Priority", "High");
                                    }
                                    else if (choice1_2_2 == 3)
                                    {
                                        testCases.FilterIssues("Priority", "Critical");
                                    }
                                }
                                    
                                else if(choice1_2 == 1)
                                {
                                    Console.Clear();
                                    var choice1_2_3 = Actions.Choose("\n\nChoose status:", "New", "InProgress", "Failed", "Done");
                                    if (choice1_2_3 == 0)
                                    {
                                        testCases.FilterIssues("Status", "New");
                                    }
                                    else if (choice1_2_3 == 1)
                                    {
                                        testCases.FilterIssues("Status", "InProgress");
                                    }
                                    else if (choice1_2_3 == 2)
                                    {
                                        testCases.FilterIssues("Status", "Failed");
                                    }
                                    else if (choice1_2_3 == 3)
                                    {
                                        testCases.FilterIssues("Status", "Done");
                                    }
                                    
                                }
                                else if(choice1_2 == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter a summary:");
                                    testCases.FilterIssues("Summary", Console.ReadLine());
                                }
                            }
                            else if(choice1 == 2)
                            {
                                Console.Clear();
                                break;
                            }

                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (testCases.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"No Test Cases\n");                           
                        }
                        else
                        {
                            Console.WriteLine($"Enter Test Case ID");
                            if (int.TryParse(Console.ReadLine(), out var elemId))
                            {
                                testCases.DeleteIssueById(elemId);
                                Console.Clear();
                                Console.WriteLine($"Test Case removed successfully\n");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Incorrect element ID\n");
                            }
                        }
                        break;
                    case 4:
                        Console.Clear();
                        if (testCases.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"No Test Cases\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Enter Test Case ID");
                            
                            if (int.TryParse(Console.ReadLine(), out var tcId))
                            {
                                testCases.RunTestCaseById(tcId);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Incorrect element ID\n");
                            }
                        }
                        break;
                    case 5:
                        Console.Clear();
                        if (bugs.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"No Bugs\n");
                        }
                        else
                        {
                            Console.WriteLine($"Enter Bug ID");
                            if (int.TryParse(Console.ReadLine(), out var bugId))
                            {
                                bugs.ShowIssueById(bugId);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Incorrect element ID\n");
                            }
                        }
                        break;
                    case 6:
                        Console.Clear();
                        if (bugs.Count == 0)
                        {
                            Console.WriteLine($"No Bugs\n");
                        }
                        else
                        {
                            Console.WriteLine($"\n\tBUGS:\n");
                            bugs.ShowAll();
                        }

                        while (bugs.Count != 0)
                        {
                            var choice1 = Actions.Choose("\n\nCHOOSE AN ACTION:", "Sort elements", "Filter elements", "Exit");
                            if (choice1 == 0)
                            {
                                Console.Clear();
                                var choice1_1 = Actions.Choose("CHOOSE AN ACTION:\n", "Sort by Priority", "Sort by Status");
                                if (choice1_1 == 0)
                                {
                                    Console.Clear();
                                    var choice1_1_1 = Actions.Choose("CHOOSE AN ACTION:\n", "Ascending priority", "Descending priority");
                                    if (choice1_1_1 == 0)
                                    {
                                        bugs.SortIssues("Priority", 1);
                                    }
                                    else if (choice1_1_1 == 1)
                                    {
                                        bugs.SortIssues("Priority", 2);
                                    }

                                }
                                else if (choice1_1 == 1)
                                {
                                    Console.Clear();
                                    var choice1_1_2 = Actions.Choose("CHOOSE AN ACTION:\n", "Ascending status", "Descending status");
                                    if (choice1_1_2 == 0)
                                    {
                                        bugs.SortIssues("Status", 1);
                                    }
                                    else if (choice1_1_2 == 1)
                                    {
                                        bugs.SortIssues("Status", 1);
                                    }
                                }

                            }
                            else if (choice1 == 1)
                            {
                                Console.Clear();
                                var choice1_2 = Actions.Choose("CHOOSE AN ACTION:\n", "Filter by Priority", "Filter by Status", "Filter by Summary");
                                if (choice1_2 == 0)
                                {
                                    Console.Clear();
                                    var choice1_2_2 = Actions.Choose("\n\nChoose priority:", "Low", "Medium", "High", "Critical");
                                    if (choice1_2_2 == 0)
                                    {
                                        bugs.FilterIssues("Priority", "Low");
                                    }
                                    else if (choice1_2_2 == 1)
                                    {
                                        bugs.FilterIssues("Priority", "Medium");
                                    }
                                    else if (choice1_2_2 == 2)
                                    {
                                        bugs.FilterIssues("Priority", "High");
                                    }
                                    else if (choice1_2_2 == 3)
                                    {
                                        bugs.FilterIssues("Priority", "Critical");
                                    }
                                }
                                else if (choice1_2 == 1)
                                {
                                    Console.Clear();
                                    var choice1_2_3 = Actions.Choose("\n\nChoose status:", "New", "InProgress", "Failed", "Done");
                                    if (choice1_2_3 == 0)
                                    {
                                        bugs.FilterIssues("Status", "New");
                                    }
                                    else if (choice1_2_3 == 1)
                                    {
                                        bugs.FilterIssues("Status", "InProgress");
                                    }
                                    else if (choice1_2_3 == 2)
                                    {
                                        bugs.FilterIssues("Status", "Failed");
                                    }
                                    else if (choice1_2_3 == 3)
                                    {
                                        bugs.FilterIssues("Status", "Done");
                                    }

                                }
                                else if (choice1_2 == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter a summary:");
                                    bugs.FilterIssues("Summary", Console.ReadLine());
                                }
                            }                       
                            else if (choice1 == 2)
                            {
                                Console.Clear();
                                break;
                            }

                        }
                        break;
                    case 7:
                        Console.Clear();
                        if (bugs.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"No Bugs\n");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Enter Bug ID");

                            if (int.TryParse(Console.ReadLine(), out var tcId))
                            {
                                ICollectionExtentions.ChangeBugStatusById(bugs, testCases, tcId);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Incorrect element ID\n");
                            }
                        }
                        break;
                        
                    case 8:
                        Console.Clear();
                        if (bugs.Count == 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"No Bugs\n");
                        }
                        else
                        {
                            Console.WriteLine($"Enter Bug ID");
                            if (int.TryParse(Console.ReadLine(), out var elemId))
                            {
                                bugs.DeleteIssueById(elemId);
                                Console.Clear();
                                Console.WriteLine($"Bug removed successfully\n");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Incorrect element ID\n");
                            }
                        }
                        break;
                    case 9:
                        return;                       
                }
            }
        }
    }
}
