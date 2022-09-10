using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcBal
{
    public interface IWallet
    {
        string Name { get; set; }
        double GetMoney();
        double GetTokens();
    }
}
