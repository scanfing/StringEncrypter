using System.Security.Cryptography;
using System.Windows;
using StringEncrypter.Controls;

namespace StringEncrypter.Encrypters
{
    public class RijndaelEncrypter : KeyIVEncrypter
    {
        #region Constructors

        public RijndaelEncrypter()
        {
            RijndaelManaged = new RijndaelManaged();
            CanDecrypt = true;
        }

        #endregion Constructors

        #region Properties

        public RijndaelManaged RijndaelManaged { get; }

        #endregion Properties

        #region Methods

        protected override FrameworkElement CreateControl()
        {
            return new RijindaelConfigControl(this);
        }

        protected override ICryptoTransform CreateDecryptor()
        {
            return RijndaelManaged.CreateDecryptor();
        }

        protected override ICryptoTransform CreateEncryptor()
        {
            return RijndaelManaged.CreateEncryptor();
        }

        #endregion Methods
    }
}