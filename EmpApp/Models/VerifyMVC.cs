using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models
{
    public class VerifyMVC
    {


        [Key]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];

        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }


    }
}
