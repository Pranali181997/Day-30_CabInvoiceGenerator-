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
        List<Ride> rides = new List<Ride>();
        public double CalculateFare(double distance, int Time)
        {
            var fair= (COST_PER_KM * distance + COST_PER_MINUTE * Time);
            if (fair > MIN_FAIR)
            {
                return fair;
            }
            return MIN_FAIR;
        }

        public void AddRide(double distance, int Time)
        {
            rides.Add(new Ride()
            {
                distance = distance,
                Time = Time
            });
        }
        public InvoiceSummary CalculateAggregate()
        {
            double fair = 0;
            foreach (Ride ride in rides)
            {
                fair += CalculateFare(ride.distance, ride.Time);
            }
            var summary = new InvoiceSummary()
            {
                noOfRide = rides.Count,
                AvgFare = fair / rides.Count,
                totalFare =(int) fair
            };
            return summary;
        }
    }
}
