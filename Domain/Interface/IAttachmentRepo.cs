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
        public AttachmentViewModel AddAttachment(AttachmentViewModel model);
    }
}
