using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAppRepository;
using EmployeeAppModels;
using EmployeeAppBusiness.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAppBusiness
{
    public class EmployeeImplement : IEmployee
    {
        private readonly EmployeeDbContext _dbobj;

        public EmployeeImplement(EmployeeDbContext _dboj)
        {
            _dbobj = _dboj;

        }

        public List<EmployeeRegistration> Get()
        {
            return _dbobj.EmployeeDetails.ToList();
        }

        public void Post(EmployeeRegistration emp1)
        {

            _dbobj.EmployeeDetails.Add(emp1);
            _dbobj.SaveChanges();
        }


        public void Delete(string username)
        {
            EmployeeRegistration emp = _dbobj.EmployeeDetails.FirstOrDefault(i => i.UserName == username);
            if (emp != null)
            {
                _dbobj.Remove(emp);
                _dbobj.SaveChanges();
            }
        }
        public EmployeeRegistration Get(string UserName)
        {
            return _dbobj.EmployeeDetails.FirstOrDefault(i => i.UserName == UserName);
        }
        public void Edit(EmployeeRegistration empe)
        {
            EmployeeRegistration emplo = _dbobj.EmployeeDetails.FirstOrDefault(i => i.UserName == empe.UserName);
            if (emplo != null)
            {
                _dbobj.EmployeeDetails.Remove(emplo);
                _dbobj.EmployeeDetails.Add(empe);
                _dbobj.SaveChanges();
            }
        }



    }
}
