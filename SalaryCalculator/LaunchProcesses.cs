using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
    public class LaunchProcesses
    {
        public List<Employee> returEmployeesList = new List<Employee>();
        private  void WriteSalaryToConsole(List<Employee> empList)
        {
            foreach (var i in empList)
            {
                Console.WriteLine(i.Name + "'s salary is: " + i.PayCheck);
            }
        }
        private  void GetCalculationsPerformed(List<Employee> empList, List<PayRate> payRatesList)
        {
            Calculation calculation = new Calculation();
            if (empList != null || payRatesList != null)
            {
                empList = calculation.GetSalaryForEmployer(empList, payRatesList);
                returEmployeesList = empList;
                WriteSalaryToConsole(empList);
            }
        }

        public  void OpenFiles(string employeePath, string salaryTablePath)
        {
            ReadFile readFile = new ReadFile();

            List<Employee> empList = readFile.GetEmployeesFile(employeePath);
            List<PayRate> payList = readFile.GetPaymentRatesFile(salaryTablePath);
            GetCalculationsPerformed(empList, payList);
        }
    }
}
