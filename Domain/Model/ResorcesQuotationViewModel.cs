using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ResorcesQuotationViewModel
    {
        public QuotationViewModel Quotaion { get; set; }
        public IEnumerable<QuotationViewModel> Quotations { get; set; }
        public Dictionary<string, string> Resource { get; set; }
    }
}
