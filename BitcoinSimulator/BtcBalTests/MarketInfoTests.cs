using Microsoft.VisualStudio.TestTools.UnitTesting;
using BtcBal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcBal.Tests
{
    [TestClass()]
    public class MarketInfoTests
    {
        [TestMethod()]
        public void UpdatePriceTest()
        {
            MarketInfo.UpdatePrice().GetAwaiter().OnCompleted(()=> { Console.WriteLine(MarketInfo.BtcPrice); });
            System.Threading.Thread.Sleep(5000);
            if (MarketInfo.BtcPrice == 0) Assert.Fail();
        }
    }
}