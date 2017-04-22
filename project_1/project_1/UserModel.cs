using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace project_1
{
    //Пока не используется
    public class UserModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public bool Validate()
        {
            var validationResult = true;
            
            var emailValidation = new EmailValidationRule();
            var loginValidation = new LoginValidationRule();
            var passwordValidation = new PasswordValidationRule();

            validationResult &= emailValidation.Validate(Email, null).IsValid;
            validationResult &= loginValidation.Validate(Login, null).IsValid;
            validationResult &= passwordValidation.Validate(Password, null).IsValid;

            return validationResult;
        }
    }
}