using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployeeBL
    {
        public bool Register(EmployeeModel add);
        List<EmployeeModel> EmployeeList();
        void editEmployee(EmployeeModel employeeModel);
        EmployeeModel getEmployeeById(int? id);
        void deleteEmployee(EmployeeModel employeeModel);

    }
}
