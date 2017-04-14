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
    public class PasswordValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value as string;
            if (password == null)
                return new ValidationResult(false, null);

            Regex passwordReg = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
            bool result = passwordReg.IsMatch(password);

            if (result)
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Минимальная длина пароля составляет 8 символов.\nПароль должен содержать строчные, прописные латинские буквы, а также цифры и знаки специального алфавита");
        }
    }
}
