using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BaseAbstractValidator<T> : AbstractValidator<T>
    {
        public string GetTranslation(string key)
        {
            return ValidatorOptions.Global.LanguageManager.GetString(key, new CultureInfo(Thread.CurrentThread.CurrentUICulture.Name));
        }

        public bool ValidateLangCode(string LangCode)
        {
            var validLangCode = new[] {"az", "en-US", "ru-RU"};
            return validLangCode.Contains(LangCode);
        }
    }
}
