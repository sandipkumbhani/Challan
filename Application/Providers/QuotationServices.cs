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
    public class QuotationServices : IQuotationServices
    {
        private readonly IQuotationRepo _quotaionRepo;
        public QuotationServices(IQuotationRepo quotaionRepo)
        {
            _quotaionRepo = quotaionRepo;
        }
        public QuotationViewModel Add(QuotationViewModel model)
        {
            return _quotaionRepo.AddDocument(model);
        }

        public QuotationViewModel Edit(QuotationViewModel model)
        {
            return _quotaionRepo.EditQuotation(model);
        }

        public QuotationViewModel Get(int id)
        {
            return _quotaionRepo.GetQutation(id);
        }

        public IEnumerable<QuotationViewModel> GetAllQuotation()
        {
            return _quotaionRepo.GetQuotaion();
        }
    }
}
