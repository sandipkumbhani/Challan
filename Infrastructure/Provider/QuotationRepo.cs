using Domain.Interface;
using Domain.Model;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Provider
{
    public class QuotationRepo : IQuotationRepo
    {
        private readonly AppDBContext _Context;
        public QuotationRepo(AppDBContext Context)
        {
            _Context=Context;
        }
        public QuotationViewModel AddDocument(QuotationViewModel Document)
        {
            _Context.Add(Document);
            _Context.SaveChanges();
            return Document;
        }

        public QuotationViewModel DeleteQuotation(QuotationViewModel Document)
        {
           _Context.Update(Document);
            _Context.SaveChanges();
            return Document;
        }

        public QuotationViewModel EditQuotation(QuotationViewModel Document)
        {
           _Context.Update(Document);
            _Context.SaveChanges();
            return Document;
        }

        public IEnumerable<QuotationViewModel> GetQuotaion()
        {
            return _Context.Quotation.Where(x => x.StatusId ==1 );
        }

        public QuotationViewModel GetQutation(int id)
        {
            return _Context.Quotation.Find(id);
        }
    }
}
