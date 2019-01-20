using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
    class Calculation
    {
        private Employee employee;
        private PayRate dailyPayRate;
        private double finalPayCheck;
        private readonly TimeSpan constantException = TimeSpan.FromHours(00.00); //There is one exception since 00:00 will be understood as the first hour of the day and not the last hour
        private readonly List<Employee> employeeSalaryList = new List<Employee>();
        public List<Employee> GetSalaryForEmployer(List<Employee> employeeList, List<PayRate> payRates)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                employee = new Employee();
                finalPayCheck = 0;
                employee = employeeList[i];//this will give me all the information of 1 employee
                for (int j = 0; j < employee.Day.Count; j++) //Loop through each day the employee worked
                {
                    dailyPayRate = payRates.Find(x => x.Name == employee.Day[j]); //Find the day information for which the employee worked
                    DateTime employeeEndHour = employee.EndHour[j];
                    DateTime employeeStartHour = employee.StartHour[j];
                    for (int k = 0; k < dailyPayRate.Day.StartRange.Count; k++)//This loop will get the pay ranges the employee worked and calculate his pay
                    {
                        if (dailyPayRate.Day.EndRange[k] > employeeStartHour || dailyPayRate.Day.EndRange[k].TimeOfDay == constantException)
                        {
                            //Normal scenario, employee only worked on the same hour range
                            if (dailyPayRate.Day.EndRange[k] >= employeeEndHour || dailyPayRate.Day.EndRange[k].TimeOfDay == constantException)
                            {
                                double workTime = (employeeEndHour - employeeStartHour).TotalHours;
                                finalPayCheck = finalPayCheck + (workTime * dailyPayRate.Day.PayAmount[k]); 
                                break;
                            }
                            //Employee worked on 2 different hour ranges
                            else if (dailyPayRate.Day.EndRange[k + 1] >= employeeEndHour || dailyPayRate.Day.EndRange[k+1].TimeOfDay == constantException)
                            {
                                double workTime = (dailyPayRate.Day.EndRange[k] - employeeStartHour).TotalHours;
                                double cost1 = dailyPayRate.Day.PayAmount[k] * workTime;
                                workTime = (employeeEndHour- dailyPayRate.Day.EndRange[k]).TotalHours;
                                double cost2 = dailyPayRate.Day.PayAmount[k+1] * workTime;
                                finalPayCheck = finalPayCheck + cost1 + cost2;
                                break;
                            }
                            //Employee worked on the 3 different possible hour ranges
                            else
                            {
                                double workTime = (dailyPayRate.Day.EndRange[k] - employeeStartHour).TotalHours;
                                double cost1 = dailyPayRate.Day.PayAmount[k] * workTime;
                                workTime = (employeeEndHour - dailyPayRate.Day.EndRange[k+1]).TotalHours;
                                double cost2 = dailyPayRate.Day.PayAmount[k + 2] * workTime;
                                workTime = (dailyPayRate.Day.EndRange[k + 1]- dailyPayRate.Day.EndRange[k]).TotalHours;
                                double cost3 = dailyPayRate.Day.PayAmount[k + 1] * workTime;
                                finalPayCheck = finalPayCheck + cost1 + cost2 + cost3;
                                break;
                            }
                        }  
                    }
                }
                employee.PayCheck = finalPayCheck; //Add the pay check for each employee and Add it to the list
                employeeSalaryList.Add(employee);                
            }
            return employeeSalaryList;
        }
    }
}
