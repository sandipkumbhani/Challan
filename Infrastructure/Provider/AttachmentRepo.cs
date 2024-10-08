using Domain.Interface;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
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
        public AttachmentsViewMovel AddAttachment(AttachmentsViewMovel model)
        {
            _context.Attachments.Add(model);
            _context.SaveChanges();
            return model;
        }

        public AttachmentsViewMovel EditAttachment(AttachmentsViewMovel model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }

        public AttachmentsViewMovel GetAttachment(int id)
        {
           return _context.Attachments.Find(id);
        }
        public IEnumerable<AttachmentsViewMovel> GetAttachments()
        {
            var result = _context.Attachments.ToList();
            return result;
        }
    }
}
