using Domain.Interface;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            var result = GetAttachments().FirstOrDefault(x => x.FollowId == model.FollowId && x.Document == model.Document);
            if (result == null)
            {
                _context.Attachments.Add(model);
                _context.SaveChanges();
            }
            return model;
        }

        public AttachmentsViewMovel AddQuotationAttachment(AttachmentsViewMovel model)
        {
            var result = GetAttachments().FirstOrDefault(x => x.QuotationId == model.QuotationId && x.Document == model.Document);
            if (result == null)
            {
                _context.Attachments.Add(model);
                _context.SaveChanges();
            }
            return model;
        }

        public AttachmentsViewMovel DeleteAttachment(AttachmentsViewMovel model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }

        public AttachmentsViewMovel EditAttachment(AttachmentsViewMovel model)
        {
            var result = GetAttachments().FirstOrDefault(x=>x.FollowId == model.FollowId && x.Document == model.Document);
            if (result == null)
            {
                _context.Attachments.Add(model);
                _context.SaveChanges();
            }
            return model;
        }

        public AttachmentsViewMovel GetAttachment(int id)
        {
           return _context.Attachments.Where(x => x.FollowId == id || x.QuotationId == id).FirstOrDefault();
        }
        public IEnumerable<AttachmentsViewMovel> GetAttachments()
        {
            var result = _context.Attachments.ToList();
            return result;
        }
      
    }
}
