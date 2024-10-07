using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Domain.Model;

namespace Application.Interface
{
    public interface IFollowServices
    {
        public DocumentViewModel Add(DocumentViewModel model);

        public IEnumerable<DocumentViewModel> GetAllDocuments();

        public DocumentViewModel Get(int id);
        public DocumentViewModel Edit(DocumentViewModel model);
        public int Delete(int id);
    }
}
 