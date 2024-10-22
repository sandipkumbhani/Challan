using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Amazon.Runtime.Internal.Settings;
using WhatsAppApi;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using System.Diagnostics;
using Application.Interface;
using Amazon.Runtime.Internal.Util;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;
using Twilio.TwiML.Messaging;
namespace Reminder
{
    public class whatsappMessageJob : IJob
    {
        private readonly IFollowServices _documentServices;
        public whatsappMessageJob(IFollowServices documentServices)
        {
            _documentServices = documentServices;
        }
        public async Task Execute(IJobExecutionContext context)
        {

            const string accountSid = "";
            const string token = "";

            TwilioClient.Init(accountSid, token);
            var DueDate = _documentServices.GetAllDocuments().Where(d => d.Date == DateOnly.FromDateTime(DateTime.Today.AddDays(-30)));
           
            if(DueDate.Count() != 0)
            {
                var message = "Daily Reminder \n";
                foreach (var dtl in DueDate)
                {
                    message += "\n Document No. :" + dtl.DocumentNo;
                    message += "\n BorrowersName : " + dtl.BorrowersName;
                    message += "\n BorrowerEmail :" + dtl.BorrowerEmail;
                    message += "\n SellersName : " + dtl.SellersName;
                    message += "\n -------------------";
                }
                Console.WriteLine(message);
                Console.WriteLine();
                //var mess = MessageResource.Create(
                    // body: message,
                     //from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                     //to: new Twilio.Types.PhoneNumber("whatsapp:+919106145603"));
               // Console.WriteLine(mess.Body);

            }
            Console.ReadLine();
        }
    }
}
