using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BtcBal
{
    public static class Bank
    {
        private static List<Account> _players = new List<Account>();


        static Bank()
        {
            _players.Add(new Account("JC"));
            Account User = _players[0];
            User.Money = 1000;
        }//-----------------------------------


        public static IWallet ReturnPlayer(int index)
        {
            return _players[index];
        }//-----------------------------------
    }//#############################################
}
