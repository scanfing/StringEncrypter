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
    /// KeyControl.xaml 的交互逻辑
    /// </summary>
    public partial class KeyControl : UserControl
    {
        #region Fields

        // Using a DependencyProperty as the backing store for Encoding. This enables animation,
        // styling, binding, etc...
        public static readonly DependencyProperty EncodingProperty =
            DependencyProperty.Register("Encoding", typeof(Encoding), typeof(KeyControl), new PropertyMetadata(Encoding.Unicode, EncodingChangedCallback));

        // Using a DependencyProperty as the backing store for Key. This enables animation, styling,
        // binding, etc...
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(string), typeof(KeyControl), new PropertyMetadata("", KeyChangedCallback));

        private KeyEncrypter _KeyEncrypter;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 默认参数配置界面
        /// </summary>
        public KeyControl(KeyEncrypter keyEncrypter)
        {
            InitializeComponent();

            _KeyEncrypter = keyEncrypter;

            CmboxEncoding.ItemsSource = Encoding.GetEncodings();

            Loaded += KeyControl_Loaded;
        }

        #endregion Constructors

        #region Properties

        public Encoding Encoding
        {
            get { return (Encoding)GetValue(EncodingProperty); }
            set { SetValue(EncodingProperty, value); }
        }

        public string Key
        {
            get { return (string)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void EncodingChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as KeyControl;
            control.OnEncodingChanged((Encoding)e.OldValue, (Encoding)e.NewValue);
        }

        private static void KeyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var kcontrol = d as KeyControl;
            kcontrol.OnKeyChanged((string)e.OldValue, (string)e.NewValue);
        }

        private void KeyControl_Loaded(object sender, RoutedEventArgs e)
        {
            Encoding = _KeyEncrypter.Encoding;
        }

        private void OnEncodingChanged(Encoding oldEncoding, Encoding newEncoding)
        {
            _KeyEncrypter.Encoding = newEncoding;
        }

        private void OnKeyChanged(string oldKey, string newKey)
        {
            _KeyEncrypter.KeyStr = newKey;
        }

        #endregion Methods
    }
}