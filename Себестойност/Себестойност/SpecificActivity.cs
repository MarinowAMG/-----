using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Себестойност
{
    public class SpecificActivity : Activity
    {
        public SpecificActivity(string code, string type, double hourlyRate, int manHours)
        : base(code, type, hourlyRate, manHours)
        {
        }

        public override double CalculatePayment()
        {
            return HourlyRate * ManHours;
        }
    }
}
