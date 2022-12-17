using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAppModels
{
    public class UserLogin
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "First Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string? UserName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Password")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }
}
