using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Себестойност
{
    public interface IActivity
    {
        void DisplayInfo();
        double CalculatePayment();
    }
}
