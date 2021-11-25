using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEncrypter.Encrypters
{
    public class Caps : Encrypter
    {
        #region Constructors

        public Caps()
        {
            CanDecrypt = true;
        }

        #endregion Constructors

        #region Methods

        public override string Decrypt(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return str.ToLower();
        }

        public override string Encrypt(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return str.ToUpper();
        }

        #endregion Methods
    }
}