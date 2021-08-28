using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringEncrypter.Encrypters;

namespace StringEncrypter.PluginDemo
{
    public class DemoEncrypter : Encrypter
    {
        #region Constructors

        public DemoEncrypter()
        {
            CanDecrypt = true;
        }

        #endregion Constructors

        #region Methods

        public override string Decrypt(string str)
        {
            var lst = new List<char>();
            foreach (var c in str)
            {
                lst.Add(c);
            }
            lst.Reverse();
            str = "";
            foreach (var c in lst)
            {
                str += c;
            }
            return str;
        }

        public override string Encrypt(string str)
        {
            var lst = new List<char>();
            foreach (var c in str)
            {
                lst.Add(c);
            }
            lst.Reverse();
            str = "";
            foreach (var c in lst)
            {
                str += c;
            }
            return str;
        }

        #endregion Methods
    }
}