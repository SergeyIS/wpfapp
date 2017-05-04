namespace project_1.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
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
