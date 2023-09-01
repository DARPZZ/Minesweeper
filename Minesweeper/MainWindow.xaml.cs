﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mineryder
{

    public partial class MainWindow : Window
    {
        Image image;
        int holdeKolonne;
        int holdeRække;
        int række;
        int Kolonne;
        Timer timer = new Timer();
        Button clickedButton;
        Knapper knapper = new Knapper();
        Button[,] buttons;
        byte[,] gameBoard;
        Bomber bomber = new Bomber();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartgameButton(object sender, RoutedEventArgs e)
        {
            timer.Start();
            timer.TimeChanged += UpdateTidText;
            var (buttonGrid, buttonArray) = knapper.GenerateButtonGrid(10, 10, buttonClickHandler, RightButtonClickHandler);
            buttons = buttonArray;

            GamerGrid.Children.Add(buttonGrid);
            gameBoard = new byte[10, 10];
            gameBoard = bomber.GenerateBomber(gameBoard);

            /*
             * used for debugging
             */
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (gameBoard[row, col] == 10)
                    {
                        TextBox textBox = new TextBox
                        {
                            Text = "Bomb",
                            FontSize = 9,
                           
                        };

                        buttons[row, col].Content = textBox;
                    }
                }
            }


        }
        private void buttonClickHandler(object sender, RoutedEventArgs e)
        {

            
            clickedButton = sender as Button;
            clickedButton.IsEnabled = false;
            
            CheckIfBombHit(clickedButton);
            CheckNeighborsForBombs(række, Kolonne);
           
        }

        private void RightButtonClickHandler(object sender, MouseButtonEventArgs e)
        {
            clickedButton = sender as Button;

            if (clickedButton.Tag == null || (bool)clickedButton.Tag == false)
            {
                clickedButton.Tag = true;
                 image = new Image();
                image.Source = new BitmapImage(new Uri("C:\\Users\\Rasmus T. Hermansen\\Downloads\\Trophy_12.PNG"));
                clickedButton.Content = image;
            }
            else
            {
                clickedButton.Tag = false;
                clickedButton.Content = "";
            }
        }

        public void CheckIfBombHit(Button button)
        {

             række = Grid.GetRow(button);

             Kolonne = Grid.GetColumn(button);

            if (gameBoard[række, Kolonne] == 10)
            {
                MessageBox.Show("BOOOOOOOOM");
                timer.Stop();
            }

        }
        
        public void CheckNeighborsForBombs(int række, int Kolonne)
        {
            int bombeTæller = 0;
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            
            for (int i = 0; i < 8; i++)
            {
                 holdeRække = række + dx[i];
                 holdeKolonne = Kolonne + dy[i];
                if (holdeRække >= 0 && holdeRække < 10 && holdeKolonne >= 0 && holdeKolonne < 10)
                {
                    if (gameBoard[holdeRække, holdeKolonne] == 10)
                    {
                        bombeTæller++;
                    }

                    if(bombeTæller == 0)
                    {

                        CheckNextDoor(holdeRække, holdeKolonne);
                        buttons[række, Kolonne].Content = "";
                    }
                }
            }
            
            clickedButton.Content = bombeTæller.ToString();
            
        }
        public void CheckNextDoor(int række, int Kolonne)
        {
            int bombeTæller = 0;
            int[] px = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] py = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int j = 0; j < 8; j++)
            {

                holdeRække = række + px[j];
                holdeKolonne = Kolonne + py[j];
               
                if (holdeRække >= 0 && holdeRække < 10 && holdeKolonne >= 0 && holdeKolonne < 10)
                {
                    
                    if (gameBoard[holdeRække, holdeKolonne] == 10)
                    {
                        bombeTæller++;
                    }
                }
            }
            if (gameBoard[række, Kolonne] < 10)
            {
                if (buttons[række,Kolonne].Content == null)
                {
                    
                    buttons[række, Kolonne].Content = bombeTæller;
                    buttons[række, Kolonne].IsEnabled = false;
                }
            }
            if (bombeTæller == 0)
            {
                buttons[række, Kolonne].Content = "";
                for (int l = 0; l < 8; l++)
                {
                    int nextRække = række + px[l];
                    int nextKolonne = Kolonne + py[l];

                    if (nextRække >= 0 && nextRække < 10 && nextKolonne >= 0 && nextKolonne < 10)
                    {
                        if (buttons[nextRække, nextKolonne].Content == null)
                        {
                            CheckNextDoor(nextRække, nextKolonne);

                        }
                    }
                    
                }
            }
        }

        #region Timer region
        private void UpdateTidText(string time)
        {

            Tid.Text = time;
        }
        #endregion


    }
}



