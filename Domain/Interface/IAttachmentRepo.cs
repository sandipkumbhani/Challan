using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public  interface IAttachmentRepo
    {
        public AttachmentsViewMovel AddAttachment(AttachmentsViewMovel model);
        public AttachmentsViewMovel EditAttachment(AttachmentsViewMovel model);
        public AttachmentsViewMovel GetAttachment(int id);
    }
}
