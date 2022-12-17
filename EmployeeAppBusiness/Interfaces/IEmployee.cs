using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAppModels;

namespace EmployeeAppBusiness.Interfaces
{
    public interface IEmployee
    {
        List<EmployeeRegistration> Get();
        EmployeeRegistration Get(string username);
        void Edit(EmployeeRegistration emp3);
        void Post(EmployeeRegistration emp1);

        void Delete(string emp2);

       


    }
}
