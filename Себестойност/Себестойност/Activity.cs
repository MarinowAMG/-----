using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Себестойност
{
    public abstract class Activity : IActivity
    {
        public string Code { get; set; }
        public string Type { get; set; }
        public double HourlyRate { get; set; }
        public int ManHours { get; set; }

        public Activity(string code, string type, double hourlyRate, int manHours)
        {
            Code = code;
            Type = type;
            HourlyRate = hourlyRate;
            ManHours = manHours;
        }

        public abstract double CalculatePayment();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Code: {Code}, Type: {Type}, Hourly Rate: {HourlyRate}, Man Hours: {ManHours}");
        }
    }
}
