using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAttachmentServices
    {
        public AttachmentsViewMovel Add(AttachmentsViewMovel model);
        public AttachmentsViewMovel Edit(AttachmentsViewMovel model);
        public AttachmentsViewMovel Get(int id);
        public int Delete(int id);

    }
}
