using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StringEncrypter.Controls;

namespace StringEncrypter.Encrypters
{
    public abstract class KeyEncrypter : Encrypter
    {
        #region Properties

        public virtual byte[] Key { get; set; }

        public virtual string KeyStr
        {
            get => Encoding.GetString(Key);
            set
            {
                Key = Encoding.GetBytes(value);
            }
        }

        #endregion Properties

        #region Methods

        protected override FrameworkElement CreateControl()
        {
            return new KeyControl(this);
        }

        #endregion Methods
    }
}