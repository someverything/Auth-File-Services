using Business.StatusMessages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.StatusMessages.Concrete
{
    public class LocalizationService : ILocalizationService
    {
        public string GetLocalizedString(string key, string culture)
        {
            return LocalizationMessages.GetLocalizedString(key, culture);
        }
    }
}
