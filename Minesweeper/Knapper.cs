using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mineryder
{
    public class Knapper
    {

        public (Grid, Button[,]) GenerateButtonGrid(int nummerAfRækker, int nummerAfColunner, RoutedEventHandler buttonClickHandler, MouseButtonEventHandler rightClickHandler)
        {
            Grid grid = new Grid();
            Button[,] buttons = new Button[nummerAfRækker, nummerAfColunner];

            for (int Række = 0; Række < nummerAfRækker; Række++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            }

            for (int kolonne = 0; kolonne < nummerAfColunner; kolonne++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int række = 0; række < nummerAfRækker; række++)
            {
                for (int kolonne = 0; kolonne < nummerAfColunner; kolonne++)
                {
                    Button button = new Button();
                    button.Name = $"btn_{række}_{kolonne}";
                    button.Width = 50;
                    button.Height = 50;
                    button.Click += buttonClickHandler;
                    button.MouseRightButtonDown += rightClickHandler;
                    buttons[række, kolonne] = button;
                    grid.Children.Add(button);
                    Grid.SetRow(button, række);
                    Grid.SetColumn(button, kolonne);

                }
            }
            return (grid, buttons);
        }

    }
}
