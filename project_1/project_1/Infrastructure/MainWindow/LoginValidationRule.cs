using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace project_1
{
    public class LoginValidationRule : ValidationRule
    {
        private int minLength = 8;
        public int MinLength
        {
            get { return minLength; }
            set { minLength = value; }
        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = value as string;
            if (login == null)
                return new ValidationResult(false, null);

            bool result = login.Length >= minLength;
            if (result)
                return new ValidationResult(true, null);

            return new ValidationResult(false, $"Логин должен содержать не менее {minLength} символов");
        }
    }
}
