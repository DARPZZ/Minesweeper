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
using System.Windows.Shapes;
using Mineryder;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MaWindow.xaml
    /// </summary>
    public partial class MaWindow : Window
    {
        public string selectedItem { get; set; }
        Bomber bom = new Bomber();
        public MaWindow()
        {

            InitializeComponent();
            AddIteams();
        }
        public void AddIteams()
        {
            ListboxFor.Items.Add("5");
            ListboxFor.Items.Add("10");
            ListboxFor.Items.Add("20");
            ListboxFor.Items.Add("30");
            ListboxFor.Items.Add("Random");
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = ListboxFor.SelectedItem.ToString();

            App.SharedData.AntalBomber = int.Parse(selectedItem);
            var anotherView = new MainWindow();
            anotherView.Show();
            this.Close();


        }


    }
}
