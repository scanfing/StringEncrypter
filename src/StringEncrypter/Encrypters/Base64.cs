using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEncrypter.Encrypters
{
    public class Base64 : Encrypter
    {
        #region Methods

        public override string Decrypt(string src)
        {
            var buff = Convert.FromBase64String(src);
            return Encoding.GetString(buff);
        }

        public override string Encrypt(string src)
        {
            var buff = Encoding.GetBytes(src);
            return Convert.ToBase64String(buff);
        }

        #endregion Methods
    }
}