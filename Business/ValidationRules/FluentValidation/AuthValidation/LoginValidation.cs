using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Entities.DTOs.AuthDTOs;
using FluentValidation;


namespace Business.ValidationRules.FluentValidation.AuthValidation
{
    public class LoginValidation : BaseAbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(x => x.EmailOrUsername)
                .NotEmpty().WithMessage(GetTranslation("EmailIsRequired"))
                .NotNull().WithMessage(GetTranslation("EmailIsRequired"));
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(GetTranslation("PasswordIsRequired"))
                .NotNull().WithMessage(GetTranslation("PasswordIsRequired"));
        }
    }
}
