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
        public void Test1()
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
    }
}