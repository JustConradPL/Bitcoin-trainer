using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace BitcoinSimulator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Timers.Timer aTime = new System.Timers.Timer(20000);
        public MainWindow()
        {

            InitializeComponent();
            BtcBal.MarketInfo.UpdatePrice();
            aTime.AutoReset = true;
            aTime.Elapsed += (object s, System.Timers.ElapsedEventArgs elapsed) => { BtcBal.MarketInfo.UpdatePrice(); };
            aTime.Start();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PriceTxt.Text = BtcBal.MarketInfo.BtcPrice.ToString() + " zł";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            double startingValue = MainMenuGrid.Width, endValue = startingValue == 0 ? 270 : 0;
            DoubleAnimation animation = new DoubleAnimation(startingValue, endValue, new Duration(new TimeSpan(0, 0, 1)));

            BackEase backEase = new BackEase();
            backEase.EasingMode = EasingMode.EaseInOut;

            animation.EasingFunction = backEase;

            animation.Completed += (object s, EventArgs ev) => { MenuIconImg.MouseDown += StackPanel_MouseDown;  };

            MainMenuGrid.BeginAnimation(WidthProperty, animation);
            MenuIconImg.MouseDown -= StackPanel_MouseDown;
        }

        private void Button_Click_1(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
