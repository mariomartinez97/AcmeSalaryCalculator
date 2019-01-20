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

        private List<PayRate> GetPaymentRatesDetails(StreamReader file)
        {            
            while ((line = file.ReadLine()) != null)
            {
                string[] valueSplit = line.Split(',');

                //Since there are several ranges for the same day, this will help put all ranges together without repeating the days
                if (payRate.Name == valueSplit[0] || payRate.Name == null)
                {
                    payRate.Name = valueSplit[0]; //Name of the day will always be the first value
                    dayInfo.StartRange.Add(Convert.ToDateTime(valueSplit[1]));  //Start hour for that range will be second
                    dayInfo.EndRange.Add(Convert.ToDateTime(valueSplit[2])); // End hour for the range will be third
                    dayInfo.PayAmount.Add(Int32.Parse(valueSplit[3]));//The amount to be payed for that range of hours will be last
                }
                else
                {
                    if (payRate.Name != null)
                    {
                        payRate.Day = dayInfo;
                        payRatesList.Add(payRate);
                        dayInfo = new DayInfo(); //since lists store a reference value, we need to create a new object so it doesnt modify the one in the list
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
                employeeDetails = new Employee(); //since lists store a reference value, we need to create a new object so it doesnt modify the one in the list

                for (int i = 0; i < indvEmployee.Length; i++)//loop through each employee to obtain the details of hours worked
                {
                    if (i==0)
                    {
                        indvEmployeeDetails = indvEmployee[i].Split('=');
                        employeeDetails.Name = indvEmployeeDetails[0];
                        indvEmployee[i] = indvEmployeeDetails[1];
                    }
                    indvEmployeeHours = indvEmployee[i].Split('-');
                    employeeDetails.Day.Add(indvEmployeeHours[0].Substring(0, 2));//The first 2 characters will return the the he worked
                    //Use Convert.ToDateTime will allow us to work with an hour format
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
            //Its important to use a try catch while reading to avoid crashing if path or file doesnt exist
            try
            {
                StreamReader file =
                    new System.IO.StreamReader(path);
                List<PayRate> paymentRateFileReturn = GetPaymentRatesDetails(file);
                return paymentRateFileReturn;

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not find file " + path); //Tell the user that the path doesnt exist
                return new List<PayRate>();
            }
        }
        public List<Employee> GetEmployeesFile(string path)
        {
            //Its important to use a try catch while reading to avoid crashing if path or file doesnt exist
            try
            {
                StreamReader file =
                    new System.IO.StreamReader(path);
                List<Employee> employeeFileReturn = GetEmployeesDetail(file);
                return employeeFileReturn;

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not find file " + path); //Tell the user that the path doesnt exist
                return new List<Employee>();
            }
        }
    }
}
