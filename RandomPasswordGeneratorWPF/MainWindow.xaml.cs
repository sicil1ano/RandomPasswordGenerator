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

namespace RandomPasswordGeneratorWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel();
            this.DataContext = vm;
        }

        private void btnGeneratePwd_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                vm.GeneratePassword();
                vm.CalculateMD5Hash();
            }
        }

        private void cbCopyPwdClipboard_Checked(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null && (cbCopyPwdClipboard.IsChecked == true))
            {
                if (!String.IsNullOrEmpty(txtPassword.Text))
                {
                    vm.CopyToClipboard();
                }
            }
        }
    }
}
