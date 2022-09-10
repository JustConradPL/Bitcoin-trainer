using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BtcBal;

namespace Testing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(MarketInfo.BtcPrice);
            await MarketInfo.UpdatePrice();
            Console.WriteLine(MarketInfo.BtcPrice);
            Console.ReadKey();
        }
    }
}
