using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PhoneSystemApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVM mainVM = new MainWindowVM();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mainVM;
        }

        /// <summary>
        /// Senario 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            StatusMessageTextBlock.Text = "A ruft B an";
            CB1.SelectedIndex = 1;
            PhoneSystemAButton.Command?.Execute(PhoneSystemAButton.CommandParameter);
            await Task.Delay(2000);
            StatusMessageTextBlock.Text = "B ruft C an";
            CB3.SelectedIndex = 1;
            PhoneSystemCButton.Command?.Execute(PhoneSystemCButton.CommandParameter);
            await Task.Delay(8000);
            StatusMessageTextBlock.Text = "fertig";
        }

        /// <summary>
        /// Senaria 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click_S2(object sender, RoutedEventArgs e)
        {
            StatusMessage2TextBlock.Text = "A ruft B ruft C ruft D an";
            CB1.SelectedIndex = 1;
            CB2.SelectedIndex = 2;
            CB3.SelectedIndex = 3;
            PhoneSystemAButton.Command?.Execute(PhoneSystemAButton.CommandParameter);
            PhoneSystemBButton.Command?.Execute(PhoneSystemBButton.CommandParameter);
            PhoneSystemCButton.Command?.Execute(PhoneSystemCButton.CommandParameter);
            await Task.Delay(10000);
            StatusMessage2TextBlock.Text = "fertig";
        }

        private async void Button_Click_S3(object sender, RoutedEventArgs e)
        {
            StatusMessage3TextBlock.Text = "A ruft B ruft A an";
            CB1.SelectedIndex = 1;
            CB2.SelectedIndex = 0;
            PhoneSystemAButton.Command?.Execute(PhoneSystemAButton.CommandParameter);
            PhoneSystemBButton.Command?.Execute(PhoneSystemBButton.CommandParameter);
            await Task.Delay(5000);
            StatusMessage3TextBlock.Text = "fertig";
        }
    }
}
