using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class AttachmentViewModel
    {
        [Key]
        public int AttachmentId { get; set; }
        public string? Document {  get; set; }
        public int? FollowId { get; set; } = null;
        [ForeignKey("FollowId")]
        public DocumentViewModel Documents {  get; set; }
        public int? QuotationId { get; set; } = null;
        [ForeignKey("QuotationId")]
        public QuotationViewModel Quotation { get; set; }
        public string SourceType { get; set; }
    }
}
