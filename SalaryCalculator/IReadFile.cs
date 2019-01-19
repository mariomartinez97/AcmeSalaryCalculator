using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
    interface IReadFile
    {
        List<PayRate> GetPaymentRatesFile(string path);
        List<Employee> GetEmployeesFile(string path);

    }
}
