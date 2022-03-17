using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeModel
    {
        public int Emp_id { get; set; }
        public string Name { get; set; }
        public string Profile_Image { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Salary { get; set; }
       
        public DateTime Start_Date { get; set; }
        public string Notes { get; set; }
        public DateTime RegisteredDate { get; set; }

    }
}
