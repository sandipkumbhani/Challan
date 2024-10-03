using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace MultiLang
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<EmployeeViewModel> employees {  get; set; } 
        public DbSet<DocumentViewModel> Follow { get; set; }
                     
        public DbSet<QuotationViewModel> Quotation {  get; set; }

        public DbSet<UserViewModel> User {  get; set; }
        public DbSet<AttachmentsViewMovel> Attachments { get; set; }
        public DbSet<AttachmentViewModel> Attachment { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
