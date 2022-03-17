using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EmployeePayrollAppMVC.Controllers
{
    public class EmployeeController : Controller
    {
        
        IEmployeeBL EmployeeBL;

        public EmployeeController(IEmployeeBL EmployeeBL)
        {
            this.EmployeeBL = EmployeeBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var empList = this.EmployeeBL.EmployeeList();
            return View(empList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] EmployeeModel model)
        {
            try
            {
                bool insertEmployee = this.EmployeeBL.Register(model);

                if (insertEmployee == true)
                {
                    
                    return View(model);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAll")]
        public IActionResult EmployeeList()
        {
            var empList = this.EmployeeBL.EmployeeList();
            return View(empList);
        }
        //[HttpGet]
        //public IActionResult Edit()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmployeeModel employee)
        {
            if (id != employee.Emp_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                EmployeeBL.editEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = EmployeeBL.getEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            var employee = EmployeeBL.getEmployeeById(id);
            EmployeeBL.deleteEmployee(employee);
            return RedirectToAction("Index");
        }


    }
}

