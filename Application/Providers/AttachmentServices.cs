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
        public AttachmentsViewMovel Add(AttachmentsViewMovel model)
        {
            return  _attachment.AddAttachment(model);
        }

        public int Delete(int id)
        {
            var result = _attachment.GetAttachment(id);
            if (result != null)
            {
                result.StatusId = 0;
                _attachment.DeleteAttachment(result);
                return 1;
            }
            return 0;
        }

        public AttachmentsViewMovel Edit(AttachmentsViewMovel model)
        {
            return _attachment.EditAttachment(model);
        }

        public AttachmentsViewMovel Get(int id)
        {
            return _attachment.GetAttachment(id);
        }
    }
}
