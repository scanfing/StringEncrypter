using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StringEncrypter.Encrypters
{
    public interface IEncrypter
    {
        #region Properties

        /// <summary>
        /// 是否支持解密
        /// </summary>
        bool CanDecrypt { get; }

        string Description { get; }

        FrameworkElement EncryptConfigView { get; }

        string Name { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 解密 （调用前先取<see cref="CanDecrypt"/>判断是否支持解密）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        string Decrypt(string str);

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        string Encrypt(string str);

        #endregion Methods
    }
}