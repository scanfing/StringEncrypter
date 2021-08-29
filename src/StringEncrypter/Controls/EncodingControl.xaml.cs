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
using StringEncrypter.Encrypters;

namespace StringEncrypter.Controls
{
    /// <summary>
    /// EncodingControl.xaml 的交互逻辑
    /// </summary>
    public partial class EncodingControl : UserControl
    {       // Using a DependencyProperty as the backing store for Encoding. This enables animation,
        #region Fields

        // styling, binding, etc...
        public static readonly DependencyProperty EncodingProperty =
            DependencyProperty.Register("Encoding", typeof(Encoding), typeof(EncodingControl), new PropertyMetadata(Encoding.Unicode, EncodingChangedCallback));

        private Encrypter _encrypter;

        #endregion Fields

        #region Constructors

        public EncodingControl(Encrypter encrypter)
        {
            _encrypter = encrypter;
            InitializeComponent();

            CmboxEncoding.ItemsSource = Encoding.GetEncodings();

            Loaded += EncodingControl_Loaded;
        }

        #endregion Constructors

        #region Properties

        public Encoding Encoding
        {
            get { return (Encoding)GetValue(EncodingProperty); }
            set { SetValue(EncodingProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void EncodingChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as EncodingControl;
            control.OnEncodingChanged((Encoding)e.OldValue, (Encoding)e.NewValue);
        }

        private void EncodingControl_Loaded(object sender, RoutedEventArgs e)
        {
            Encoding = _encrypter.Encoding;
        }

        private void OnEncodingChanged(Encoding oldEncoding, Encoding newEncoding)
        {
            _encrypter.Encoding = newEncoding;
        }

        #endregion Methods
    }
}