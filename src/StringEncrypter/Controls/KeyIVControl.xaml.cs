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
    /// KeyIVControl.xaml 的交互逻辑
    /// </summary>
    public partial class KeyIVControl : UserControl
    {
        #region Fields

        // Using a DependencyProperty as the backing store for IV.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IVProperty =
            DependencyProperty.Register("IV", typeof(string), typeof(KeyIVControl), new PropertyMetadata("", IVChangedCallback));

        // Using a DependencyProperty as the backing store for Key.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(string), typeof(KeyIVControl), new PropertyMetadata("", KeyChangedCallback));

        private KeyIVEncrypter _KeyIVEncrypter;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// 默认参数配置界面
        /// </summary>
        public KeyIVControl(KeyIVEncrypter keyIVEncrypter)
        {
            InitializeComponent();
            _KeyIVEncrypter = keyIVEncrypter;
        }

        #endregion Constructors

        #region Properties

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

        #endregion Properties

        #region Methods

        private static void IVChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var kivcontrol = d as KeyIVControl;
            kivcontrol.OnIVChanged((string)e.OldValue, (string)e.NewValue);
        }

        private static void KeyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var kivcontrol = d as KeyIVControl;
            kivcontrol.OnKeyChanged((string)e.OldValue, (string)e.NewValue);
        }

        private void OnIVChanged(string oldIV, string newIV)
        {
            _KeyIVEncrypter.IVStr = newIV;
        }

        private void OnKeyChanged(string oldKey, string newKey)
        {
            _KeyIVEncrypter.KeyStr = newKey;
        }

        #endregion Methods
    }
}