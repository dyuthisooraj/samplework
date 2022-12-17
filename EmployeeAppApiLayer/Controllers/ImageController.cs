using EmployeeAppRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAppApiLayer.Controllers
{
    public class ImageController : Controller
    {
        private readonly EmployeeDbContext _employeeContext;

        public ImageController(EmployeeDbContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        // GET: ImageController
        public async Task<IActionResult> Upload()
        {
            return View(await _employeeContext.EmployeeDetails.ToListAsync());
        }

        [HttpPost("FileUpload")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            var size = files.Sum(h => h.Length);
            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await stream.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { files.Count, size, filePaths });

        }

    }

}




            