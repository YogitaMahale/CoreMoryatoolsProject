using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
//using SendGrid;
//using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CoreMoryatools.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
