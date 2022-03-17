using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeRL EmployeeRL;
        public EmployeeBL(IEmployeeRL EmployeeRL)
        {
            this.EmployeeRL = EmployeeRL;
        }
        public bool Register(EmployeeModel add)
        {
            try
            {
                return this.EmployeeRL.Register(add);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<EmployeeModel> EmployeeList()
        {
            try
            {
                return this.EmployeeRL.EmployeeList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void editEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.EmployeeRL.editEmployee(employeeModel);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public void deleteEmployee(EmployeeModel employee)
        {
            try
            {
                this.EmployeeRL.deleteEmployee(employee);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public EmployeeModel getEmployeeById(int? id)
        {
            try
            {
                return this.EmployeeRL.getEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
