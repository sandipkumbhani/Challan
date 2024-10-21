using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Reminder
{
    public class EmailBackGroudProvider : IEmailBackGroudInterface
    {
        private readonly IConfiguration _configuration;
        public EmailBackGroudProvider(IConfiguration configuration)
        {
                _configuration = configuration;
        }
        public string DueaDateDocumentbody(IEnumerable<DocumentViewModel> documents)
        {
            string body = "";
            body =
                   "<table class=\"table table table-striped table-bordered\">" +
                   "<thead>" +
                   "<tr>" +
                   "<th class=\"col-3\">Document No.</th>" +
                   "<th class=\"col-3\">Borrowers Name</th>" +
                   "<th class=\"col-3\">Borrower Email</th>" +
                   "<th class=\"col-3\">SellersName</th>" +
                   "</tr>" +
                   "</thead>" +
                   "<tbody>";
            foreach (var dtl in documents)
            {
                body += $"<tr>" +
                         $"<td>{dtl.DocumentNo}</td>" +
                         $"<td>{dtl.BorrowersName}</td>" +
                         $"<td>{dtl.BorrowerEmail}</td>" +
                         $"<td>{dtl.SellersName}</td>" +
                         "</tr>";
            }
            body += "</tbody></table>";
            return body;
        }
        public void SendEmail(MailAddress fromEmail, MailAddress toEmail, string body, string subject)
        {
            var smtpClient = new SmtpClient
            {
                Host = _configuration["EmailSetting:Host"],
                Port = Convert.ToInt16(_configuration["EmailSetting:Port"]),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_configuration["EmailSetting:EmailAddress"], _configuration["EmailSetting:EmailPassword"]),
            };
            using (var mess = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtpClient.Send(mess);
            }
        }
        public string DueaDateQuotationbody(IEnumerable<QuotationViewModel> quotations)
        {
            string body = "";
            body =
                 "<table class=\"table table table-striped table-bordered\">" +
                 "<thead>" +
                 "<tr>" +
                 "<th class=\"col-2\"> Application No.</th>" +
                 "<th class=\"col-2\"> Name</th>" +
                 "<th class=\"col-3\"> SurveyNo</th>" +
                 "<th class=\"col-2\"> Pro_Refe_no</th>" +
                 "<th class=\"col-2\"> ProcessFees</th>" +
                 "</tr>" +
                 "</thead>" +
                 "<tbody>";
            foreach (var dtl in quotations)
            {
                body += $"<tr>" +
                         $"<td>{dtl.ApplicationNo}</td>" +
                         $"<td>{dtl.Name}</td>" +
                         $"<td>{dtl.SurveyNo}</td>" +
                         $"<td>{dtl.Pro_Refe_no}</td>" +
                         $"<td>{dtl.ProcessFees}</td>" +
                         "</tr>";
            }
            body += "</tbody></table>";
            return body;
        }
    }
}
