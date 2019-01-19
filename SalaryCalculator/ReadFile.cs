using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
    class ReadFile:IReadFile
    {        
        private string line;
        private string[] indvEmployee;
        private string[] indvEmployeeDetails;
        private string[] indvEmployeeHours;
        readonly List<Employee> employees = new List<Employee>();
        Employee employeeDetails = new Employee();
        PayRate payRate = new PayRate();
        DayInfo dayInfo = new DayInfo();
        readonly List<PayRate> payRatesList = new List<PayRate>();
        //private System.IO.StreamReader file;

        private List<PayRate> GetPaymentRatesDetails(StreamReader file)
        {            
            while ((line = file.ReadLine()) != null)
            {
                string[] valueSplit = line.Split(',');

                if (payRate.Name == valueSplit[0] || payRate.Name == null)
                {
                    payRate.Name = valueSplit[0];
                    dayInfo.StartRange.Add(Convert.ToDateTime(valueSplit[1]));
                    dayInfo.EndRange.Add(Convert.ToDateTime(valueSplit[2]));
                    dayInfo.PayAmount.Add(Int32.Parse(valueSplit[3]));
                }
                else
                {
                    if (payRate.Name != null)
                    {
                        payRate.Day = dayInfo;
                        payRatesList.Add(payRate);
                        dayInfo = new DayInfo();
                        payRate = new PayRate();        
                    }
                    payRate.Name = valueSplit[0];
                    dayInfo.StartRange.Add(Convert.ToDateTime(valueSplit[1]));
                    dayInfo.EndRange.Add(Convert.ToDateTime(valueSplit[2]));
                    dayInfo.PayAmount.Add(Int32.Parse(valueSplit[3]));
                }
            }
            payRate.Day = dayInfo;
            payRatesList.Add(payRate);
            file.Close();
            return payRatesList;            
        }
        private List<Employee> GetEmployeesDetail(StreamReader file)
        {
            while ((line = file.ReadLine())!= null)
            {
                indvEmployee = line.Split(',');
                employeeDetails = new Employee();

                for (int i = 0; i < indvEmployee.Length; i++)
                {
                    if (i==0)
                    {
                        indvEmployeeDetails = indvEmployee[i].Split('=');
                        employeeDetails.Name = indvEmployeeDetails[0];
                        indvEmployee[i] = indvEmployeeDetails[1];
                    }
                    indvEmployeeHours = indvEmployee[i].Split('-');
                    employeeDetails.Day.Add(indvEmployeeHours[0].Substring(0, 2));
                    employeeDetails.StartHour.Add(Convert.ToDateTime(indvEmployeeHours[0].Substring(2)));
                    employeeDetails.EndHour.Add(Convert.ToDateTime(indvEmployeeHours[1]));
                }
                employees.Add(employeeDetails);
            }
            file.Close();            
            return employees;
        }
        public List<PayRate> GetPaymentRatesFile(string path)
        {
            try
            {
                StreamReader file =
                    new System.IO.StreamReader(path);
                List<PayRate> paymentRateFileReturn = GetPaymentRatesDetails(file);
                return paymentRateFileReturn;

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not find file " + path);
                return new List<PayRate>();
            }
        }
        public List<Employee> GetEmployeesFile(string path)
        {
            try
            {
                StreamReader file =
                    new System.IO.StreamReader(path);
                List<Employee> employeeFileReturn = GetEmployeesDetail(file);
                return employeeFileReturn;

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not find file " + path);
                return new List<Employee>();
            }
        }
    }
}
