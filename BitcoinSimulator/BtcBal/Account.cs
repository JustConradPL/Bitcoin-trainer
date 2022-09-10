using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcBal
{
    public class Account : IWallet
    {
        public string Name { get; set; }
        public List<Investment> TransactionHistory = new List<Investment>();

        public double Money { get; set; }
        public double Tokens { get; set; }

        public Account(string UserName)
        {
            Name = UserName;
        }//--------------------------------------

        public void Invest(double AmountBought)
        {
            if (AmountBought > Money) throw new Exception("Amount is too big");
            TransactionHistory.Add(new Investment(MarketInfo.BtcPrice * AmountBought, AmountBought, InvestmentType.RealToCrypto, DateTime.Now));
            Money -= MarketInfo.BtcPrice * AmountBought; Tokens += AmountBought;
        }//--------------------------------------

        public void Sell(double AmountSold)
        {
            if (AmountSold > Tokens) throw new Exception("Amount is too big");
            TransactionHistory.Add(new Investment(AmountSold, AmountSold * MarketInfo.BtcPrice, InvestmentType.CryptoToReal, DateTime.Now));
            Money += AmountSold * MarketInfo.BtcPrice; Tokens -= AmountSold;
        }//-----------------------------------

        public double GetMoney()
        {
            return Money;
        }//-----------------------------------

        public double GetTokens()
        {
            return Tokens;
        }//-----------------------------------
    }//############################################
}
