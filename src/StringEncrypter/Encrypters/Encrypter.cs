using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using StringEncrypter.Controls;

namespace StringEncrypter.Encrypters
{
    public abstract class Encrypter : IEncrypter
    {
        #region Fields

        private FrameworkElement _frameElement;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// IEncrypter 抽象基类，子类需重写实现 <see cref="Encrypt(string)"/>。
        /// 将 <see cref="CanDecrypt"/> 标记为 true 时，需实现 <see cref="Decrypt(string)" /> 方法。
        /// </summary>
        public Encrypter()
        {
            Name = GetType().Name;
        }

        #endregion Constructors

        #region Properties

        public virtual bool CanDecrypt { get; protected set; } = false;

        public string Description { get; protected set; }

        /// <summary>
        /// 加解密时使用的字符串编码，默认UTF8
        /// </summary>
        public Encoding Encoding { get; protected set; } = Encoding.UTF8;

        public FrameworkElement EncryptConfigView
        {
            get
            {
                if (_frameElement is null)
                {
                    _frameElement = CreateControl();
                }
                return _frameElement;
            }
            protected set
            {
                _frameElement = value;
            }
        }

        public virtual int KeyLength { get; protected set; } = 0;

        public string Name { get; }

        #endregion Properties

        #region Methods

        public virtual string Decrypt(string str)
        {
            return "方法未实现";
        }

        public virtual string Encrypt(string str)
        {
            return "方法未实现";
        }

        protected virtual FrameworkElement CreateControl()
        {
            return new TextBlock() { Text = Name };
        }

        #endregion Methods
    }
}