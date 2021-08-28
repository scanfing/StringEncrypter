using System.Security.Cryptography;
using System.Windows;
using StringEncrypter.Controls;

namespace StringEncrypter.Encrypters
{
    public class DES : KeyIVEncrypter
    {
        #region Fields

        private DESCryptoServiceProvider _provider;

        #endregion Fields

        #region Constructors

        public DES()
        {
            _provider = new DESCryptoServiceProvider();
            Key = _provider.Key;
            IV = _provider.IV;

            CanDecrypt = true;
        }

        #endregion Constructors

        #region Methods

        protected override FrameworkElement CreateControl()
        {
            return new KeyIVControl(this);
        }

        protected override ICryptoTransform CreateDecryptor()
        {
            return _provider.CreateDecryptor(Key, IV);
        }

        protected override ICryptoTransform CreateEncryptor()
        {
            return _provider.CreateEncryptor(Key, IV);
        }

        #endregion Methods
    }
}