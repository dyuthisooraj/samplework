using EmployeeAppBusiness.Interfaces;
using EmployeeAppModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EmployeeAppApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _emp;

        private readonly IWebHostEnvironment _hostEnvironment;
        public EmployeeController(IEmployee emp, IWebHostEnvironment webHostEnvironment)
        {
            _emp = emp;
            _hostEnvironment = webHostEnvironment;
        }

        [HttpGet("Get")]
        
        public ActionResult<List<EmployeeRegistration>> Get()
        {
            var result = _emp.Get();
            return Ok(result);
        }

        [HttpPost("Post")]
        //[Route]
        ///Bind("UserName,Password,Title,FirstName,LastName,Gender,EmailId,MobileNumber,Address,Country,Salary,Designation,ImageFile")]  EmployeeRegistration emp1, int acc_id
        public async Task <IActionResult> Post(EmployeeDto emp)
        {
            EmployeeRegistration emp1 = new EmployeeRegistration();
            //string uniqueFileName = UploadedFile(emp1);
            //emp1.ImageUrl = uniqueFileName;

            if (!ModelState.IsValid)
            {

                return BadRequest("Is not valid");
            }
            else
            {
                emp.Address = emp1.Address;
                emp.Gender = emp1.Gender;
                emp.Salary = emp1.Salary;
                emp.MobileNumber = emp1.MobileNumber;
                emp.UserName = emp1.UserName;
                emp.LastName = emp1.LastName;
                emp.FirstName = emp1.FirstName;
                emp.EmailId = emp1.EmailId;
                emp.Title = emp1.Title;
                emp.Password = emp1.Password;
                emp.ImageUrl = emp1.ImageUrl;
                _emp.Post(emp1);
                return Ok();
            }
            
        }
        [HttpPost]
        public async Task<string> PostImage(IFormFile image)
        {

            //string uniqueFileName = UploadedFile(emp1);
            //emp1.ImageUrl = uniqueFileName;
            var special = Guid.NewGuid().ToString();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"~/images", special + "-" + image.FileName);
            using (FileStream ms = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(ms);
            }
            var filename = special + "=" + image.FileName;
            return filePath;


        }
        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        [Route("Delete/{UserName}")]
        public ActionResult Delete(string username)
        {
            _emp.Delete(username);
            return Ok();

        }

        [HttpGet]
        [Route("Get/{username}")]
        public ActionResult<EmployeeRegistration> Get(string UserName)
        {
            return _emp.Get(UserName);
         }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(EmployeeRegistration emp1)
        {
            if (!ModelState.IsValid)
                return BadRequest("Is not valid");
            _emp.Edit(emp1);
            return Ok();
        }

        //[HttpGet]
        //public async Task<string> UploadFile(IFormFile file)
        //{
        //    var special = Guid.NewGuid().ToString();
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"~/images", special + "-" + file.FileName);
        //    using (FileStream ms = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(ms);
        //    }
        //    var filename = special + "=" + file.FileName;
        //    return filePath;

        //}

        //private string UploadedFile(EmployeeRegistration emp3)
        //{
        //    string uniqueFileName = null;

        //    if (emp3.ImageFile != null)
        //    {

        //        string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + emp3.ImageFile.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            emp3.ImageFile.CopyTo(fileStream);
        //        }
        //        return uniqueFileName;
        //    }

        //}
        //        //string webRootPath = _hostEnvironment.WebRootPath;
        //string fileName = Path.GetFileNameWithoutExtension(emp3.ImageFile.FileName);
        //string extension = Path.GetExtension(emp3.ImageFile.FileName);
        //uniqueFileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //string path = Path.Combine(webRootPath + "/Image/", uniqueFileName);
        //using (var fileStream = new FileStream(path, FileMode.Create))
        //{
        //    await emp3.ImageFile.CopyToAsync(fileStream);
        //}
        //return uniqueFileName;
        //    }
        //}
        //public async Task<IActionResult> Create([Bind("ImageId,Title,ImageFile")] ImageModelDTO imageModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var imagevariable = new ImageModel()
        //        {
        //            ImageFile = imageModel.ImageFile,
        //            ImageName = null,
        //            Title = imageModel.Title
        //        };
        //        //save image to wwwroot/image
        //        string webRootPath = _hostEnvironment.WebRootPath;
        //        string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
        //        string extension = Path.GetExtension(imageModel.ImageFile.FileName);
        //        imagevariable.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
        //        string path = Path.Combine(webRootPath + "/Image/", fileName);
        //        using (var fileStream = new FileStream(path, FileMode.Create))
        //        {
        //            await imagevariable.ImageFile.CopyToAsync(fileStream);
        //        }

        //        //insert record

        //        _context.Add(imagevariable);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(imageModel);
        //}
    }

}
