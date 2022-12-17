using EmployeeAppModels;
using EmployeeAppRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAppApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeContext;

        public DesignationController(EmployeeDbContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        [HttpPost]
        [Route("designation")]
        public IActionResult designation([FromBody] Designation designation1)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid request");
            _employeeContext.Designations.Add(designation1);
            _employeeContext.SaveChanges();
            return Ok();
        }


        [HttpGet]
        public List<Designation> Get()
        {
            return _employeeContext.Designations.ToList();
            //var data = _employeeContext.employee.Include(c => c.designations).ToList();
            //return Ok(data);
        }
    }
}
