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
        RideRepository rideRepository = new RideRepository();

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

        public void AddRide(string userId, double distance, int Time)
        {
           var userRides= rideRepository.GetRideByUserId(userId);
            if (userRides == null)
            {
                var userride = new List<Ride>();
                userride.Add(new Ride()
                {
                    distance = distance,
                    Time = Time
                });
                rideRepository.AddRideInRideRepo(userId, userride);
            }
            else
            {
                userRides.Add(new Ride()
                {
                    distance = distance,
                    Time = Time
                });
                rideRepository.AddRideInRideRepo(userId, userRides);
            }                                 
        }
        public InvoiceSummary CalculateAggregate(string userId)
        {
            var userRides = rideRepository.GetRideByUserId(userId);
            double fair = 0;
            foreach (Ride ride in userRides)
            {
                fair += CalculateFare(ride.distance, ride.Time);
            }
            var summary = new InvoiceSummary()
            {
                noOfRide = userRides.Count,
                AvgFare = fair / userRides.Count,
                totalFare =(int) fair
            };
            return summary;
        }
    }
}
