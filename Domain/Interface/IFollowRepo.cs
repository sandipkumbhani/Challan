using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IFollowRepo
    {
        public DocumentViewModel AddDocumentDtl(DocumentViewModel document);
        public IEnumerable<DocumentViewModel> GetDocuments();

        public DocumentViewModel GetDocument(int id);
        public DocumentViewModel EditFollow(DocumentViewModel document);
        public DocumentViewModel DeleteFollow(DocumentViewModel DocumentViewModel);
    }
}
