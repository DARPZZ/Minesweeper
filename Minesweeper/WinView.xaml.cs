using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Mineryder;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for WinView.xaml
    /// </summary>
    public partial class WinView : Window
    {
        public WinView()
        {
            InitializeComponent();
           
           
        }
        private void SwitchToMainView()
        {
            
            var mainView = new MainWindow();
            mainView.Show();
            this.Close();
        }

        private void hej_Click(object sender, RoutedEventArgs e)
        {
            SwitchToMainView();
        }

  

        private void playAgain(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Jeg er her");
            gifMediaElement.Position = TimeSpan.FromMilliseconds(1);
            gifMediaElement.Play();
        }
    }
}
