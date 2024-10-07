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
    public class FollowServices : IFollowServices
    {
        private readonly IFollowRepo _documentRepo;
        public FollowServices(IFollowRepo documentRepo)
        {
            _documentRepo = documentRepo;
        }
        public DocumentViewModel Add(DocumentViewModel model)
        {
            return _documentRepo.AddDocumentDtl(model);
        }

        public int Delete(int id)
        {
            var res = _documentRepo.GetDocument(id);
            if(res != null)
            {
                res.StatusId = 0;
                _documentRepo.DeleteFollow(res);
                return 1;
            }
            return 0;
        }

        public DocumentViewModel Edit(DocumentViewModel model)
        {
            return _documentRepo.EditFollow(model);
        }

        public DocumentViewModel Get(int id)
        {
            return _documentRepo.GetDocument(id);
        }

        public IEnumerable<DocumentViewModel> GetAllDocuments()
        {
            return _documentRepo.GetDocuments();
        }
    }
}
