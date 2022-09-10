using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcBal
{
    public class Investment
    {
        public InvestmentType TypeOfInvestment;
        public double Spent, Bought;
        public DateTime Date;


        public Investment(double amountSpent, double amountBought, InvestmentType type, DateTime date)
        {
            TypeOfInvestment = type;
            Spent = amountSpent;
            Bought = amountBought;
            Date = date;
        }//----------------------------------------------
    }//########################################################

    public enum InvestmentType
    {
        RealToCrypto,
        CryptoToReal
    }//########################################################
}
