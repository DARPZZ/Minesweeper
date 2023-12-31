﻿using System;
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
            RunItThough();


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
            
            ko.Position = TimeSpan.FromMilliseconds(1);
            hest.Position = TimeSpan.FromMilliseconds(1);
            gifMediaElement.Position = TimeSpan.FromMilliseconds(1);
            gifMediaElement.Play();
            ko.Play();
            hest.Play();
            
        }
        private void RunItThough()
        {
            ko.MinHeight = 200;
            ko.MinWidth = 200;
            string[] gifFiles = Directory.GetFiles(gifsFolderPath, "*.gif");

            if (gifFiles.Length > 0)
            {
                int fileCount = Directory.GetFiles(gifsFolderPath, "*.*", SearchOption.AllDirectories).Length;
                
                int randomIndex1 = random.Next(0, gifFiles.Length);
                int randomIndex2 = random.Next(0, gifFiles.Length);
                string selectedGifFile = gifFiles[randomIndex1];
                ko.Source = new Uri(selectedGifFile);
                hest.Source = new Uri(gifFiles[randomIndex2]);
            }
        }
    }
}


