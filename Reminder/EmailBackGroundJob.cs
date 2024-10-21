using Microsoft.Extensions.Logging;
using Quartz;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Application.Interface;

namespace Reminder
{
    public class EmailBackGroundJob : IJob
    {
        private readonly ILogger<EmailBackGroundJob> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFollowServices _documentServices;
        private readonly IQuotationServices _quotationServices;
        private readonly IEmailBackGroudInterface _emailBackGroudProvider;
        public EmailBackGroundJob(ILogger<EmailBackGroundJob> logger, IConfiguration configuration,IFollowServices documentServices, IQuotationServices quotationServices, IEmailBackGroudInterface emailBackGroudProvider)
        {
            _logger = logger;
            _configuration = configuration;
            _documentServices = documentServices;
            _quotationServices = quotationServices;
            _emailBackGroudProvider = emailBackGroudProvider;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var fromAddress = new MailAddress(_configuration["EmailSetting:EmailAddress"], _configuration["EmailSetting:EmailHeader"]);
                var toAddress = new MailAddress(_configuration["EmailSetting:ToEmailAddress"]);
               
                const string subject = "Daily reminder mail";
                string body = "";
                var dueDate = _documentServices.GetAllDocuments().Where(d => d.Date == DateOnly.FromDateTime(DateTime.Today.AddDays(-30)));                    
                if(dueDate.Any())
                {
                    body = _emailBackGroudProvider.DueaDateDocumentbody(dueDate); 
                    _emailBackGroudProvider.SendEmail(fromAddress, toAddress, body, subject);                   
                }

                body = "";
                var dueDateQuotion = _quotationServices.GetAllQuotation().Where(d => d.App_Date == DateOnly.FromDateTime(DateTime.Today.AddDays(-30)));                
                if (dueDateQuotion.Any())
                {
                    body = _emailBackGroudProvider.DueaDateQuotationbody(dueDateQuotion);
                    _emailBackGroudProvider.SendEmail(fromAddress, toAddress, body, subject);
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
