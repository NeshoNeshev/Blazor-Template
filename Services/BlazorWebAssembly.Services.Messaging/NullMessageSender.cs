using BlazorWebAssembly.Services.Messaging.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Services.Messaging
{
    public class NullMessageSender : IEmailSender
    {
        public Task SendEmailAsync(
            string from,
            string fromName,
            string to,
            string subject,
            string htmlContent,
            IEnumerable<EmailAttachment> attachments = null)
        {
            return Task.CompletedTask;
        }
    }
}
