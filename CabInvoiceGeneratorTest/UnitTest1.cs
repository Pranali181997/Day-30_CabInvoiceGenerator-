using Day30CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
      public CabInvoiceGenerator cabInvoiceGenerator;
        [SetUp]
        public void Setup()
        {
            cabInvoiceGenerator = new CabInvoiceGenerator();
        }
        //generate Fair
        [Test]
        public void CalculateFare()
        {
           double fair= cabInvoiceGenerator.CalculateFare(2,5);
            Assert.AreEqual(25,fair);
        }
        [Test]
        public void CheckForMinimumFairAsFive()
        {
            double fair = cabInvoiceGenerator.CalculateFare(0, 0);
            Assert.AreEqual(5, fair);
        }       
        [Test]
        public void CalAggFairAndMulRides()
        {
            cabInvoiceGenerator.AddRide("pranali",2, 5);
            cabInvoiceGenerator.AddRide("panu",12, 15);
            cabInvoiceGenerator.AddRide("panu",12, 15);
               
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate("pranali");
            Assert.AreEqual(25, invoiceSummary.totalFare);
        }
        [Test]//UC-3-ENHANCEDINVOICE
        public void CalAggFairAndMulRidesTestNoOfRide()
        {
            cabInvoiceGenerator.AddRide("parul",2, 5);
            cabInvoiceGenerator.AddRide("helo",12, 15);
            cabInvoiceGenerator.AddRide("helo", 12, 15);

            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate("helo");
            Assert.AreEqual(2, invoiceSummary.noOfRide);
        }
        [Test]
        public void AddMultipleRIdeToCheckAgrFare()
        {
            cabInvoiceGenerator.AddRide("pp",2, 5);
            cabInvoiceGenerator.AddRide("sd",12, 15);     

            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate("sd");
            Assert.AreEqual(135, invoiceSummary.AvgFare);
        }
        //UC-4-ENHANCEDSERVICE  
        [Test]
        public void AddMutipleRideForDifferentUsers()
        {
            cabInvoiceGenerator.AddRide("Pranali", 2, 5);
            cabInvoiceGenerator.AddRide("Pranali", 12, 15);
            cabInvoiceGenerator.AddRide("parul" ,12, 15);

            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate("parul");
            Assert.AreEqual(135, invoiceSummary.AvgFare);
        }

    }
}