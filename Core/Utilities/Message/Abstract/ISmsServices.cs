using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Message.Abstract
{
    public interface ISmsServices
    {
        Task<bool> SendOtpSmsAsync(string phoneNumber, string otp);
    }
}
