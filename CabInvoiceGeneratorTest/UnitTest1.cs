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
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(160, invoiceSummary.totalFare);
        }
        [Test]
        public void CalAggFairAndMulRidesTestNoOfRide()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(2, invoiceSummary.noOfRide);
        }
        [Test]
        public void AddMultipleRIdeToCheckAgrFare()
        {
            cabInvoiceGenerator.AddRide(2, 5);
            cabInvoiceGenerator.AddRide(12, 15);
            var invoiceSummary = cabInvoiceGenerator.CalculateAggregate();
            Assert.AreEqual(80, invoiceSummary.AvgFare);
        }
    }
}