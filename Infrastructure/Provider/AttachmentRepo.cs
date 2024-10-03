using Domain.Interface;
using Domain.Model;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Provider
{
    public class AttachmentRepo : IAttachmentRepo
    {
        private readonly AppDBContext _context;
        public AttachmentRepo(AppDBContext context)
        {
            _context = context;
        }
        public AttachmentViewModel AddAttachment(AttachmentViewModel model)
        {
            _context.Attachment.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
