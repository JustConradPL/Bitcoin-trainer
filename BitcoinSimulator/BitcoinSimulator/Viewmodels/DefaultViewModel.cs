using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BitcoinSimulator.Viewmodels
{
    public class DefaultViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string FieldName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(FieldName));
        }//------------------------------------------
    }//#######################################################
}
