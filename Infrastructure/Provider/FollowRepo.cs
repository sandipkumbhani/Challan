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
    public class FollowRepo : IFollowRepo
    {
        private readonly AppDBContext _context;
        public FollowRepo(AppDBContext context)
        {
            _context = context;
        }
        public DocumentViewModel AddDocumentDtl(DocumentViewModel document)
        {
            _context.Add(document);
            _context.SaveChanges();
            return document;
        }

        public DocumentViewModel DeleteFollow(int id)
        {
            return null;
        }

        public DocumentViewModel EditFollow(DocumentViewModel document)
        {
            _context.Follow.Update(document);
            _context.SaveChanges();
            return document;
        }

        public DocumentViewModel GetDocument(int id)
        {
            return _context.Follow.Find(id);
        }
        public IEnumerable<DocumentViewModel> GetDocuments()
        {
            return _context.Follow;
        }
    }
}
