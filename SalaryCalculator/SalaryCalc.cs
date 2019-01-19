using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Services;
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

            ReadFile readFile = new ReadFile();
            
            List<Employee> empList = readFile.GetEmployeesFile(employeePath);            
            List<PayRate> payList = readFile.GetPaymentRatesFile(salaryTablePath);
            GetCalculationsPerformed(empList, payList);
            
            Console.ReadLine();
        }

        private static void WriteSalaryToConsole(List<Employee> empList)
        {
            foreach (var i in empList)
            {
                Console.WriteLine(i.Name + "'s salary is: " + i.PayCheck);
            }
        }
        private static void GetCalculationsPerformed(List<Employee> empList, List<PayRate> payRatesList)
        {
            Calculation calculation = new Calculation();
            if (empList != null || payRatesList != null)
            {
                empList = calculation.GetSalaryForEmployer(empList, payRatesList);
                WriteSalaryToConsole(empList);
            }
            
        }
    }
}
