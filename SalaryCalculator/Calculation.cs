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
        private readonly TimeSpan constantException = TimeSpan.FromHours(00.00);
        private readonly List<Employee> employeeSalaryList = new List<Employee>();
        public List<Employee> GetSalaryForEmployer(List<Employee> employeeList, List<PayRate> payRates)
        {
            for (int i = 0; i < employeeList.Count; i++)
            {
                employee = new Employee();
                finalPayCheck = 0;
                employee = employeeList[i];//me da un empleado
                for (int j = 0; j < employee.Day.Count; j++)
                {
                    dailyPayRate = payRates.Find(x => x.Name == employee.Day[j]);
                    DateTime employeeEndHour = employee.EndHour[j];
                    DateTime employeeStartHour = employee.StartHour[j];
                    for (int k = 0; k < dailyPayRate.Day.StartRange.Count; k++)//loop por los pay ranges
                    {
                        if (dailyPayRate.Day.EndRange[k] > employeeStartHour || dailyPayRate.Day.EndRange[k].TimeOfDay == constantException)
                        {
                            if (dailyPayRate.Day.EndRange[k] >= employeeEndHour || dailyPayRate.Day.EndRange[k].TimeOfDay == constantException)
                            {
                                double workTime = (employeeEndHour - employeeStartHour).TotalHours;
                                finalPayCheck = finalPayCheck + (workTime * dailyPayRate.Day.PayAmount[k]);
                                break;
                            }
                            else if (dailyPayRate.Day.EndRange[k + 1] >= employeeEndHour || dailyPayRate.Day.EndRange[k+1].TimeOfDay == constantException)
                            {
                                double workTime = (dailyPayRate.Day.EndRange[k] - employeeStartHour).TotalHours;
                                double cost1 = dailyPayRate.Day.PayAmount[k] * workTime;
                                workTime = (employeeEndHour- dailyPayRate.Day.EndRange[k]).TotalHours;
                                double cost2 = dailyPayRate.Day.PayAmount[k+1] * workTime;
                                finalPayCheck = finalPayCheck + cost1 + cost2;
                                break;
                            }
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
                employee.PayCheck = finalPayCheck;
                employeeSalaryList.Add(employee);                
            }
            return employeeSalaryList;
        }
    }
}
