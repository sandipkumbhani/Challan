using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IQuotationServices
    {
        public QuotationViewModel Add(QuotationViewModel model);
        public IEnumerable<QuotationViewModel> GetAllQuotation();

        public QuotationViewModel Get(int id);
        public QuotationViewModel Edit(QuotationViewModel model);
    }
}
