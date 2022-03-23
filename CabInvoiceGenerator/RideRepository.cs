using System;
using System.Collections.Generic;
using System.Text;

namespace Day30CabInvoiceGenerator
{
   public class RideRepository
    {
        public Dictionary<string, List<Ride>> userrides;
        
        public RideRepository()
        {
            userrides = new Dictionary<string, List<Ride>>();
        }
        public void AddRideInRideRepo(string userId, List<Ride> rides)
        {
            userrides[userId] = rides;
        }
        public List<Ride> GetRideByUserId(string userId)
        {
            try
            {
              return userrides[userId];
            }
           catch(Exception ex)
            {
                return null;
            }
        }
    }
}
