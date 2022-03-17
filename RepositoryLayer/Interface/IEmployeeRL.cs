using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        public bool Register(EmployeeModel add);
        List<EmployeeModel> EmployeeList();
        void editEmployee(EmployeeModel employeeModel);
        EmployeeModel getEmployeeById(int? id);

        void deleteEmployee(EmployeeModel employeeModel);
    }
}
