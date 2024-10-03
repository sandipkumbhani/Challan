using Application.Interface;
using Domain.Interface;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Providers
{
    public class AttachmentServices : IAttachmentServices
    {
        private readonly IAttachmentRepo _attachment;
        public AttachmentServices(IAttachmentRepo attachment)
        {
            _attachment = attachment;
        }
        public AttachmentViewModel Add(AttachmentViewModel model)
        {
            return  _attachment.AddAttachment(model);
        }
    }
}
