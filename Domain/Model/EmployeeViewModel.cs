using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Amazon.Auth.AccessControlPolicy;



namespace Domain.Model
{
    public class EmployeeViewModel
    {
        
            [Key]
            public int Id { get; set; }
            [Display(ResourceType = typeof(Resource))]
            [EmailAddress]
            public string Email { get; set; }
            [Display(ResourceType = typeof(Resource))]
            public string Name { get; set; }
            [Display(ResourceType = typeof(Resource))]
            public string Address { get; set; }
        
    }

    
}
