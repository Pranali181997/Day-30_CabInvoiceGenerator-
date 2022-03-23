using System;
using System.Collections.Generic;
using System.Text;

namespace Day30CabInvoiceGenerator
{
    public class CabInvoiceGenerator
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const int MIN_FAIR = 5;
        public double CalculateFare(double distance, int Time)
        {
            var fair= (COST_PER_KM * distance + COST_PER_MINUTE * Time);
            if (fair > MIN_FAIR)
            {
                return fair;
            }
            return MIN_FAIR;
        }
    }
}
