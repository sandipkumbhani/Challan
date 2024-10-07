using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IQuotationRepo
    {
        public QuotationViewModel AddDocument(QuotationViewModel Document);

        public IEnumerable<QuotationViewModel> GetQuotaion();

        public QuotationViewModel GetQutation(int id);
        public QuotationViewModel EditQuotation(QuotationViewModel Document);
        public QuotationViewModel DeleteQuotation(QuotationViewModel Document);
    }
}
