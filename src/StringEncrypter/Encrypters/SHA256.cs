using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StringEncrypter.Extensitions;

namespace StringEncrypter.Encrypters
{
    public class SHA256 : Encrypter
    {
        #region Methods

        public override string Encrypt(string str)
        {
            byte[] inputBytes = Encoding.GetBytes(str);
            var sha = new SHA256CryptoServiceProvider();
            byte[] result = sha.ComputeHash(inputBytes);
            return result.ToHexString();
        }

        #endregion Methods
    }
}