using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Mineryder
{

    public partial class MainWindow : Window
    {
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
            timer.TimeChanged += UpdateTimerText;
            var (buttonGrid, buttonArray) = knapper.GenerateButtonGrid(10, 10, buttonClickHandler, RightButtonClickHandler);
            buttons = buttonArray;
            GamerGrid.Children.Add(buttonGrid);
            gameBoard = new byte[10, 10];
            gameBoard = bomber.GenerateBomber(gameBoard);
        }
        private void buttonClickHandler(object sender, RoutedEventArgs e)
        {
            clickedButton = sender as Button;
            CheckIfBombHit(clickedButton);
            reveal(sender);
        }

        private void RightButtonClickHandler(object sender, MouseButtonEventArgs e)
        {
            clickedButton = sender as Button;

            if (clickedButton.Tag == null || (bool)clickedButton.Tag == false)
            {
                clickedButton.Tag = true;
                Image image = new Image();
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

            int row = Grid.GetRow(button);

            int col = Grid.GetColumn(button);

            if (gameBoard[row, col] == 10)
            {
                MessageBox.Show("BOOOOOOOOM");
                timer.Stop();
            }

        }
        public void reveal(object sender)
        {
            clickedButton = sender as Button;

            if (clickedButton != null)
            {
                int række = Grid.GetRow(clickedButton);
                int Kolonne = Grid.GetColumn(clickedButton);


                Debug.WriteLine("række: " + række + " kolonne: " + Kolonne);
            }
        }

        #region Timer region
        private void UpdateTimerText(string time)
        {

            Tid.Text = time;
        }
        #endregion


    }
}



