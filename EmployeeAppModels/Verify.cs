using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAppModels
{
    public class Verify
    {

            [Key]
            [Column(TypeName = "VARCHAR")]
            [StringLength(50)]
            public string VUserName { get; set; } = string.Empty;
            public byte[] PasswordHash { get; set; } = new byte[32];
            public byte[] PasswordSalt { get; set; } = new byte[32];

            public DateTime TokenCreated { get; set; }
            public DateTime TokenExpires { get; set; }
    }
}
