using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MultiLang;

namespace Infrastructure.Provider
{
    [DisallowConcurrentExecution]
    public class SendMailJob : IJob
    {
        private readonly ILogger<SendMailJob> _logger;
        private readonly AppDBContext _context;
        public SendMailJob(ILogger<SendMailJob> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("{UtcNow}",DateTime.UtcNow);
            string frommail = "bookcatcher24@gmail.com";
            string frompassword = "digv yqpc neas hiiv";

            MailMessage mm = new MailMessage();
            mm.From=new MailAddress(frommail);
            mm.Subject = "Follow Document Reminder";
            mm.To.Add(new MailAddress("hinalgohel135@gmail.com"));
            string body= "<table>";
            var record= _context.Follow.Where(x => x.StatusId == 1 &&  x.Date == DateOnly.FromDateTime(DateTime.Today.AddDays(-30)));
            body += "<tr> <td>Document No</td><td>Document Type</td><td>Date</td></tr>";
            foreach (var dtl in record)
            {
                body += "<tr>";
                body += "<td>" + dtl.DocumentNo + "</td>";
                body += "<td>" + dtl.DocumentType + "</td>";
                body += "<td>" + (dtl.Date.HasValue ? dtl.Date.Value.ToString("dd MMM yyyy") : "") + "</td>";
                body += "</tr>";
            }
            body +="</table>";
            mm.Body = body;
            mm.IsBodyHtml = true;

            var SmtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(frommail, frompassword),
                EnableSsl = true,
            };
            SmtpClient.Send(mm);
            return Task.CompletedTask;
        }
    }
}
