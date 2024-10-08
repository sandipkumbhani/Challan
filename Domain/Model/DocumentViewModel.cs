using Amazon.Auth.AccessControlPolicy;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Domain.Model
{
    public class DocumentViewModel
    {
        [Key]
        public int Id { get; set; }
       
        public string DocumentNo { get; set; }
        
        public DateOnly? Date { get; set; }

        public string? BorrowersName { get; set; }
        [EmailAddress]
        public string? BorrowerEmail { get; set; }
        public string? SellersName { get; set; }

        public string? DocumentType { get; set; }
        public string? PropertyDetails { get; set; }

        public string? EDharaCenter { get; set; }
        public string? DharaCenterNo { get; set; }
        public string? DharaCenter {  get; set; }

        public string? CitySurveyNo {  get; set; }

        public string? CitySurvey {  get; set; }
        public string? CityTalati {  get; set; }

        public string? GramPanchayat {  get; set; }   
        public string? DocumentPayment {  get; set; }
        public string? Document {  get; set; }
        public int StatusId { get; set; } = 1;

    }
}
