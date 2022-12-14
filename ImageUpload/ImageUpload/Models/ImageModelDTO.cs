using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ImageUpload.Models
{
    public class ImageModelDTO
    {
    
        public int ImageId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
