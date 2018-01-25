using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            DataAccess Data = new DataAccess();
            while (repeat)
            {
                Console.WriteLine("Enter SQL command: ");
                string userCommand = Console.ReadLine();

                bool queryIsClean = true;

                // To strip out drop/delete/truncate/insert/update
                string[] forbiddenKeywords = new string[] { "exec", "drop", "delete", "truncate", "create", "insert", "update" };
                foreach (string keyword in forbiddenKeywords)
                {
                    if (userCommand.ToLower().Contains(keyword))
                    {
                        Console.WriteLine(string.Format("Forbidden keywords used, you may not use any of the following: {0}", string.Join(",", forbiddenKeywords)));
                        queryIsClean = false;
                        continue;
                    }
                }

                if (queryIsClean)
                {
                    var sb = Data.ExecuteQueries(userCommand);
                    Console.WriteLine(sb.ToString());
                }

                Console.WriteLine("Would you like to enter another sql command (y/n)? ");
                string answer = Console.ReadLine();

                if (answer != "y")
                {
                    repeat = false;
                }
                else
                {
                    repeat = true;
                }
            }
        }
    }
}
