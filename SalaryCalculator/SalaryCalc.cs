using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
    public class SalaryCalc
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ACME salary calculator");
            Console.WriteLine("For the salary calculation please press enter:");
            Console.ReadLine();

            string employeePath = @"..\\InputFiles\EmployeeWorkHours.txt";
            string salaryTablePath = @"..\\InputFiles\SalaryTable.txt";

            LaunchProcesses launchProcesses = new LaunchProcesses();

            launchProcesses.OpenFiles(employeePath, salaryTablePath);

            Console.ReadLine();
        }

       
    }
}
