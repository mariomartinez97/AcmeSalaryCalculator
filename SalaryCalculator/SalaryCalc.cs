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

            //Since exe file will generate on SalaryCalculator folder, it is important to add it on the path
            string employeePath = @"..\\SalaryCalculator\bin\InputFiles\EmployeeWorkHours.txt";
            string salaryTablePath = @"..\\SalaryCalculator\bin\InputFiles\SalaryTable.txt";

            LaunchProcesses launchProcesses = new LaunchProcesses();

            //launch process will internally call other classes to read the files and do the calculations
            launchProcesses.OpenFiles(employeePath, salaryTablePath);

            Console.ReadLine();
        }

       
    }
}
