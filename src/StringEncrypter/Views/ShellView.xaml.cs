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
using System.Windows.Shapes;
using StringEncrypter.ViewModels;

namespace StringEncrypter.Controls
{
    /// <summary>
    /// ShellView.xaml 的交互逻辑
    /// </summary>
    public partial class ShellView : Window
    {
        #region Constructors

        public ShellView()
        {
            InitializeComponent();
            Loaded += ShellView_Loaded;
        }

        #endregion Constructors

        #region Methods

        private void ShellView_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ShellViewModel;
            vm.OnViewLoaded();
        }

        #endregion Methods
    }
}