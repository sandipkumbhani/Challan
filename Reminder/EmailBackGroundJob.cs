using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using Domain.Model;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Application.Interface;
using Microsoft.VisualBasic;

namespace Reminder
{
    public class EmailBackGroundJob : IJob
    {
        private readonly ILogger<EmailBackGroundJob> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFollowServices _documentServices;
        public EmailBackGroundJob(ILogger<EmailBackGroundJob> logger, IConfiguration configuration,IFollowServices documentServices)
        {
            _logger = logger;
            _configuration = configuration;
            _documentServices = documentServices;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var fromAddress = new MailAddress(_configuration["EmailSetting:EmailAddress"], _configuration["EmailSetting:EmailHeader"]);
                var toAddress = new MailAddress("kalpesh.dev540@gmail.com");
                const string subject = "Daily reminder mail";
                var DueDate = _documentServices.GetAllDocuments().Where(d => d.Date == DateOnly.FromDateTime(DateTime.Today.AddDays(-30)));                
                string body = 
                    "<table class=\"table table table-striped table-bordered\">" +
                    "<thead>" +
                    "<tr>" +
                    "<th class=\"col-1\">Document No.</th>" +
                    "<th class=\"col-1\">Borrowers Name</th>" +
                    "<th class=\"col-1\">Borrower Email</th>" +
                    "<th class=\"col-3\">SellersName</th>" +
                    "</tr>" +
                    "</thead>" +
                    "<tbody>";
                    foreach (var dtl in DueDate)
                    {
                        body += $"<tr>" +
                                 $"<td>{dtl.DocumentNo}</td>" +
                                 $"<td>{dtl.BorrowersName}</td>" +
                                 $"<td>{dtl.BorrowerEmail}</td>" +
                                 $"<td>{dtl.SellersName}</td>" +
                                 //$"<td><a href=\"/path/to/pdf/{dtl.DocumentNo}.pdf\">Download</a></td>" +
                                 "</tr>";
                    }
                    body += "</tbody></table>";

                var smtpClient = new SmtpClient
                {
                    Host = _configuration["EmailSetting:Host"],
                    Port = Convert.ToInt16(_configuration["EmailSetting:Port"]),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_configuration["EmailSetting:EmailAddress"], _configuration["EmailSetting:EmailPassword"]),
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true                   
                })
                {
                    smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }           
        }
    }
}
