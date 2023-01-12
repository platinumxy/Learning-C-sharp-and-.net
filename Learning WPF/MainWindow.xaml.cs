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

namespace Learning_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SeeInNextPage_Checked(object sender, RoutedEventArgs e)
        {
            this.ToTheNextPage.IsEnabled = true;
        }
        private void SeeInNextPage_Unchecked(object sender, RoutedEventArgs e)
        {
            this.ToTheNextPage.IsEnabled = false;
        }
    }
}
