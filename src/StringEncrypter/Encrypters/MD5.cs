using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StringEncrypter.Extensitions;

namespace StringEncrypter.Encrypters
{
    public class MD5 : Encrypter
    {
        #region Methods

        public override string Encrypt(string str)
        {
            byte[] data = Encoding.GetBytes(str);
            var md5 = new MD5CryptoServiceProvider();
            byte[] bytes = md5.ComputeHash(data);
            return bytes.ToHexString();
        }

        #endregion Methods
    }
}