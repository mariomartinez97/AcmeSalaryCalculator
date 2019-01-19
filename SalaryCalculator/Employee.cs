using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator
{
    class Employee
    {
        public Employee()
        {
            this.Name = string.Empty;
            this.Day = new List<string>();
            this.StartHour = new List<DateTime>();
            this.EndHour = new List<DateTime>();
            this.PayCheck = 0.0d;
        }
        public string Name { get; set; }
        public List<String> Day { get; set; }
        public List<DateTime> StartHour { get; set; }
        public List<DateTime> EndHour { get; set; }
        public double PayCheck { get; set; }
    }

    public class DayInfo
    {
        public DayInfo()
        {
            this.StartRange = new List<DateTime>();
            this.EndRange = new List<DateTime>();
            this.PayAmount = new List<int>();
        }        
        public List<DateTime> StartRange { get; set; }
        public List<DateTime> EndRange { get; set; }
        public List<int> PayAmount { get; set; }
    }


    public class PayRate
    {
        public string Name { get; set; }
        public DayInfo Day { get; set; }
        public PayRate(){}
    }
}

