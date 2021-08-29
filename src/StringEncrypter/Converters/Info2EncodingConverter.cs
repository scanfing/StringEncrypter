using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StringEncrypter.Converters
{
    public class Info2EncodingConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EncodingInfo einfo)
                return einfo.GetEncoding();
            return Encoding.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Encoding encoding)
            {
                return Encoding.GetEncodings().FirstOrDefault(p => p.Name.Equals(encoding.WebName, StringComparison.OrdinalIgnoreCase));
            }
            throw new Exception("input invalid.");
        }

        #endregion Methods
    }
}