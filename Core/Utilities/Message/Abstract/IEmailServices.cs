using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Message.Abstract
{
    public interface IEmailServices
    {
        Task SendEmailAsync(EmailMetadata emailData);
    }
}
