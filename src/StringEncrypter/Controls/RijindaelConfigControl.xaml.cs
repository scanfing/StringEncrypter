using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// RijindaelConfigControl.xaml 的交互逻辑
    /// </summary>
    public partial class RijindaelConfigControl : UserControl
    {
        #region Fields

        // Using a DependencyProperty as the backing store for Encoding. This enables animation,
        // styling, binding, etc...
        public static readonly DependencyProperty EncodingProperty =
            DependencyProperty.Register("Encoding", typeof(Encoding), typeof(RijindaelConfigControl), new PropertyMetadata(Encoding.Unicode, EncodingChangedCallback));

        // Using a DependencyProperty as the backing store for IV. This enables animation, styling,
        // binding, etc...
        public static readonly DependencyProperty IVProperty =
            DependencyProperty.Register("IV", typeof(string), typeof(RijindaelConfigControl), new PropertyMetadata("", IVChangedCallback));

        // Using a DependencyProperty as the backing store for Key. This enables animation, styling,
        // binding, etc...
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(string), typeof(RijindaelConfigControl), new PropertyMetadata("", KeyChangedCallback));

        private RijndaelEncrypter _rEncrypter;

        private RijndaelManaged _rijndael;

        #endregion Fields

        #region Constructors

        public RijindaelConfigControl(RijndaelEncrypter rijndaelecpter)
        {
            _rEncrypter = rijndaelecpter;
            _rijndael = rijndaelecpter.RijndaelManaged;

            InitializeComponent();

            CmboxEncoding.ItemsSource = Encoding.GetEncodings();

            CmboxCipherMode.Items.Add(CipherMode.CBC);
            CmboxCipherMode.Items.Add(CipherMode.ECB);
            CmboxCipherMode.Items.Add(CipherMode.OFB);
            CmboxCipherMode.Items.Add(CipherMode.CFB);
            CmboxCipherMode.Items.Add(CipherMode.CTS);

            CmboxPaddingMode.Items.Add(PaddingMode.None);
            CmboxPaddingMode.Items.Add(PaddingMode.PKCS7);
            CmboxPaddingMode.Items.Add(PaddingMode.Zeros);
            CmboxPaddingMode.Items.Add(PaddingMode.ISO10126);
            CmboxPaddingMode.Items.Add(PaddingMode.ANSIX923);

            Loaded += RijindaelConfigControl_Loaded;
        }

        #endregion Constructors

        #region Properties

        public Encoding Encoding
        {
            get { return (Encoding)GetValue(EncodingProperty); }
            set { SetValue(EncodingProperty, value); }
        }

        public RijndaelEncrypter Encrypter => _rEncrypter;

        public string IV
        {
            get { return (string)GetValue(IVProperty); }
            set { SetValue(IVProperty, value); }
        }

        public string Key
        {
            get { return (string)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        public RijndaelManaged RijndaelManaged { get => _rijndael; }

        #endregion Properties

        #region Methods

        private static void EncodingChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RijindaelConfigControl;
            control.OnEncodingChanged((Encoding)e.OldValue, (Encoding)e.NewValue);
        }

        private static void IVChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RijindaelConfigControl;
            control.OnIVChanged((string)e.OldValue, (string)e.NewValue);
        }

        private static void KeyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RijindaelConfigControl;
            control.OnKeyChanged((string)e.OldValue, (string)e.NewValue);
        }

        private void OnEncodingChanged(Encoding oldEncoding, Encoding newEncoding)
        {
            _rEncrypter.Encoding = newEncoding;
        }

        private void OnIVChanged(string oldIV, string newIV)
        {
            _rEncrypter.IVStr = newIV;
        }

        private void OnKeyChanged(string oldKey, string newKey)
        {
            _rEncrypter.KeyStr = newKey;
        }

        private void RijindaelConfigControl_Loaded(object sender, RoutedEventArgs e)
        {
            Encoding = _rEncrypter.Encoding;
        }

        #endregion Methods
    }
}