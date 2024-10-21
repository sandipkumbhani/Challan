using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ResourceDocumentViewModel
    {
        public DocumentViewModel Document { get; set; }
        public IEnumerable<DocumentViewModel> Documents { get; set; }

        public Dictionary<string, string> Resource {  get; set; }
    }
}
