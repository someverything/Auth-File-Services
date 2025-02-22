using Entities.DTOs.AuthDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation.AuthValidation
{
    public class RegisterValidation : BaseAbstractValidator<RegisterDTO>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(GetTranslation("EmailIsRequired"))
                .NotNull().WithMessage(GetTranslation("EmailIsRequired"))
                .EmailAddress().WithMessage(GetTranslation("EmailIsValid"));

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(GetTranslation("UsernameIsRequired"))
                .NotNull().WithMessage(GetTranslation("UsernameIsRequired"))
                .MinimumLength(6).WithMessage(GetTranslation("UsernameTooShort"));

            RuleFor(x => x.Firstname)
                .NotEmpty().WithMessage(GetTranslation("FirstnameIsRequired"))
                .NotNull().WithMessage(GetTranslation("FirstnameIsRequired"))
                .Must(NotContainDigits).WithMessage(GetTranslation("FirstnameNoDigits"));

            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage(GetTranslation("LastnameIsRequired"))
                .NotNull().WithMessage(GetTranslation("LastnameIsRequired"))
                .Must(NotContainDigits).WithMessage(GetTranslation("LastnameNoDigits"));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(GetTranslation("PasswordIsRequired"))
                .NotNull().WithMessage(GetTranslation("PasswordIsRequired"));

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(GetTranslation("ConfirmPasswordIsRequired"))
                .NotNull().WithMessage(GetTranslation("ConfirmPasswordIsRequired"))
                .Equal(x => x.Password).WithMessage(GetTranslation("PasswordsMustMatch"));
        }

        private bool NotContainDigits(string value)
        {
            return !string.IsNullOrEmpty(value) && !value.Any(char.IsDigit);
        }
    }
}
