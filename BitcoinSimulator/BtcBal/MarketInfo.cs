using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Globalization;

namespace BtcBal
{
    public static class MarketInfo
    {
        private static HttpClient client;
        private static HttpClientHandler handler = new HttpClientHandler();

        public static float BtcPrice { get; private set; }

        static MarketInfo()
        {
            handler.UseDefaultCredentials = true;

            client = new HttpClient(handler);
        }//---------------------------------------------------

        public static async Task UpdatePrice(int tries = 3)
        {
            
            decimal? currentPrice = new decimal?();

            while (!currentPrice.HasValue && tries > 0)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(@"https://blockchain.info/tobtc?currency=PLN&value=1");

                    // Make sure response got accepted
                    response.EnsureSuccessStatusCode();

                    string data = await response.Content.ReadAsStringAsync();

                    currentPrice = Convert.ToDecimal(data, CultureInfo.InvariantCulture);

                    if (currentPrice.HasValue)
                    {
                        BtcPrice = Convert.ToSingle(1 /currentPrice);
                        return;
                    }

                }
                catch (Exception)
                {
                    //wait a second and try again.
                    await Task.Delay(1000);
                    tries--;
                }
            }

            throw new Exception("For some reason I can't update the price");
        }//------------------------------------------

    }//########################################################
}
