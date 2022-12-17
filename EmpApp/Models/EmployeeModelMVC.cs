
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models
{
    public class EmployeeModelMVC
    {

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Please Enter Password")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
        public string? Title { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; } = null!;

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "First Name is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50, MinimumLength = 3)]
        public string? LastName { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string? Gender { get; set; }


        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string? EmailId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Mobile")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        //[RegularExpression("^[0-9]{10}&")]
        public string? MobileNumber { get; set; }


        [Required(ErrorMessage = "Employee Address is required")]
        [Column(TypeName = "VARCHAR")]
        [StringLength(300)]
        public string? Address { get; set; }

        [Display(Name = "Country")]
        [Column(TypeName = "VARCHAR(50)")]
        public string? Country { get; set; }

        [Display(Name = "Salary")]
        public int Salary { get; set; }

        [Display(Name = "Designation")]
        [Column(TypeName = "VARCHAR(50)")]
        public string Designation { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        public string ImageUrl { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
