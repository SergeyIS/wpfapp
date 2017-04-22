using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace project_1
{
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = value as string;
            if (email == null)
                return new ValidationResult(false, null);

            Regex emailReg = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");
            bool result = emailReg.IsMatch(email.ToLower());
            if (result)
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Некорректное значение Email");
        }
    }
}
