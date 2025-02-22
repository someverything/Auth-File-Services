using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.StatusMessages.Abstract
{
    public interface ILocalizationService
    {
        string GetLocalizedString(string key, string culture);
    }
}
