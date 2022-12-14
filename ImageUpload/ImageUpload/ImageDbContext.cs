using ImageUpload.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageUpload
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext(DbContextOptions<ImageDbContext> options) : base(options)
        { }

        public DbSet<ImageModel> Images { get; set; }
    }
}
