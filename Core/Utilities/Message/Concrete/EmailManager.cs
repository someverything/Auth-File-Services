using Core.Entities;
using Core.Utilities.Message.Abstract;
using FluentEmail.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Message.Concrete
{
    public class EmailManager : IEmailServices
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailManager(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task SendEmailAsync(EmailMetadata emailData)
        {
            await _fluentEmail
                .To(emailData.ToAddress)
                .Subject(emailData.Subject)
                .Body(emailData.Body)
                .SendAsync();
        }
    }
}
