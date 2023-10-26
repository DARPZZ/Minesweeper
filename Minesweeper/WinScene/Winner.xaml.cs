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
using Mineryder;

namespace Minesweeper.WinScene
{
    /// <summary>
    /// Interaction logic for Winner.xaml
    /// </summary>
    public partial class Winner : UserControl
    {
        public Winner()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ((App)App.Current).ChangeUserControl(typeof(MainWindow));
        }
    }
}
