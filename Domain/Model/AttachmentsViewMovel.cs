using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class AttachmentsViewMovel
    {
        [Key]
        public int AttchmentId { get; set; }
        public string? Document {  get; set; }
        public int? FollowId { get; set; } = null;
        public int? QuotationId { get; set; } = null;
        public string? SourceType { get; set; }
    }
}
