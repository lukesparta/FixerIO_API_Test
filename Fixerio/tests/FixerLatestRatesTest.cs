using System;
using NUnit.Framework;

namespace Fixerio.tests
{
    [TestFixture()]
    public class FixerLatestRatesTest
    {
        private FixerLatestService fixerLatestRates = new FixerLatestService();
        [Test()]
        public void WebCallSuccessCheck()
        {
            Assert.AreEqual(true, fixerLatestRates.fixerLatestDTO.LatestRates.success);
        }

        //Total rates check

        [Test()]
        public void CountRates()
        {
            Assert.AreEqual(168, fixerLatestRates.getRates());
        }

        //All rates are floats

        [Test()]
        public void isFloat()
        {
            Assert.AreEqual(true, fixerLatestRates.checkIfFloat());
        }

        //base check
        [Test()]
        public void baseChecker()
        {
            Assert.AreEqual(true, fixerLatestRates.baseCheck());
        }

        //date
        [Test()]
        public void dateChecker()
        {
            Assert.AreEqual(true, fixerLatestRates.dateCheck());
        }

        //time stamp
        [Test()]
        public void timeStampChecker()
        {
            Assert.AreEqual(true, fixerLatestRates.timeStampCheck());
        }
    }
}
