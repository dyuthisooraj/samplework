using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAppModels
{
    public class Designation
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [StringLength(50, MinimumLength = 3)]
        public string? DesignationCategories{ get; set; } 
    }
}
