using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private string gifsFolderPath = "C:\\Users\\rasmu\\source\\repos\\Minesweeper\\Minesweeper\\FunnyGifs\\";
        Random random = new Random();
        private void playAgain(object sender, RoutedEventArgs e)
        {


            string[] gifFiles = Directory.GetFiles(gifsFolderPath, "*.gif");

            if (gifFiles.Length > 0)
            {
                
                int randomIndex = random.Next(0, gifFiles.Length);
                string selectedGifFile = gifFiles[randomIndex];
                ko.Source = new Uri(selectedGifFile);
            }
            ko.Position = TimeSpan.FromMilliseconds(1);
            gifMediaElement.Position = TimeSpan.FromMilliseconds(1);
            gifMediaElement.Play();
            ko.Play();

        }
    }
}


