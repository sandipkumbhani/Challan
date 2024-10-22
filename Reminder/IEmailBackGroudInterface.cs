using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    public interface IEmailBackGroudInterface
    {
        public string DueaDateDocumentbody(IEnumerable<DocumentViewModel> documents);
        public void SendEmail(MailAddress fromEmail, MailAddress toEmail, string body, string subject);
        public string DueaDateQuotationbody(IEnumerable<QuotationViewModel> quotations);
    }
}
