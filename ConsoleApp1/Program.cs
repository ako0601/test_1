using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = 0;
            int nn;
            Employee[] employees;
            int[] num;
            double average;
            string filename;
            string query;



            // catch missing arguments error.
            try
            {
                filename = args[0];
                query = args[1];

                // catch file not found exception.
                try
                {
                    var sr = new StreamReader(filename);
                    var sr2 = new StreamReader(query);
                    nn = int.Parse(sr2.ReadLine());
                    n = int.Parse(sr.ReadLine());
                    employees = new Employee[n];
                    num = new int[nn];
                    average = 0;

                    // reading lines by for loop
                    for (int i = 0; i < n; i++)
                    {
                        string nextLine = sr.ReadLine();
                        employees[i] = new Employee(nextLine);

                    }
                    for (int i = 0; i < nn; i++)
                    {
                        int nl = int.Parse(sr2.ReadLine());
                        num[i] = nl;
                    }
                    int count2 = 0;
                    foreach (int j in num)
                    {
                        int count = 0;
                        foreach (Employee i in employees)
                        {
                            if (i.id == j)
                            {
                                int c = count + 1;
                                Console.WriteLine("Looking for " + j + " ... Found " + i.name + " at position " + count + " after " + (count + 1) + " comparisons.");
                                average += count + 1;
                            }
                            count++;
                        }
                        count2++;
                    }

                    Console.WriteLine("Average number of comparisons overall : " + average / nn);

                    sr2.Close();
                    sr.Close();
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("File has not found.");
                }
            }
            catch (IndexOutOfRangeException a)
            {
                Console.WriteLine("Missing argument line");
            }

        }
    }

    class Employee
    {
        public string name;
        public int id;
        private int age;
        private string job;
        private int year;

        public Employee(string data)
        {
            string[] fields = data.Split('|');
            name = fields[0];
            id = int.Parse(fields[1]);
            age = int.Parse(fields[2]);
            job = fields[3];
            year = int.Parse(fields[4]);
        }
    }
}