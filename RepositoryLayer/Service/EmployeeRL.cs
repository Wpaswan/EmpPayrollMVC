
using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    
    public class EmployeeRL : IEmployeeRL
    {
        private SqlConnection sqlConnection;

        public EmployeeRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public bool Register(EmployeeModel add)
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("employeePayroll"));

            try
            {
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("sp_AddEmpForm", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    sqlCommand.Parameters.AddWithValue("@Name", add.Name);
                    sqlCommand.Parameters.AddWithValue("@Profile_Image ", add.Profile_Image);
                    sqlCommand.Parameters.AddWithValue("@Gender", add.Gender);
                    sqlCommand.Parameters.AddWithValue("@Department ", add.Department);
                    

                    sqlCommand.Parameters.AddWithValue("@Salary", add.Salary);
                    sqlCommand.Parameters.AddWithValue("@Start_Date ", add.Start_Date);
                    sqlCommand.Parameters.AddWithValue("@Notes", add.Notes);
                    sqlCommand.Parameters.AddWithValue("@RegisteredDate ", add.RegisteredDate);

                    int result = sqlCommand.ExecuteNonQuery();
                    if (result > 0)

                        return true;
                    else
                        return false;
                   

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public List<EmployeeModel> EmployeeList()
        {
            sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("employeePayroll"));
            try
            {
                List<EmployeeModel> listemployee = new List<EmployeeModel>();
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_GetAllEmpForm", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                   
                    while (rdr.Read())
                    {
                        EmployeeModel employee = new EmployeeModel();
                        employee.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Profile_Image = rdr["Profile_Image"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.Salary = rdr["Salary"].ToString();
                        employee.Start_Date = Convert.ToDateTime(rdr["Start_Date"]);
                        employee.Notes = rdr["Notes"].ToString();
                        employee.RegisteredDate = Convert.ToDateTime(rdr["RegisteredDate"]);

                       


        listemployee.Add(employee);
                    }
                    sqlConnection.Close();

                }
                return listemployee;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public void editEmployee(EmployeeModel update)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("sp_Update_EmpForm", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_id", update.Emp_id);
                cmd.Parameters.AddWithValue("@Name", update.Name);
                cmd.Parameters.AddWithValue("@Profile_Image", update.Profile_Image);
                cmd.Parameters.AddWithValue("@Gender", update.Gender);
                cmd.Parameters.AddWithValue("@Department", update.Department);
                cmd.Parameters.AddWithValue("@Salary", update.Salary);
                cmd.Parameters.AddWithValue("@Start_Date", update.Start_Date);
                cmd.Parameters.AddWithValue("@Notes", update.Notes);
                cmd.Parameters.AddWithValue("@RegisteredDate", update.RegisteredDate);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
      
        public EmployeeModel getEmployeeById(int? id)
        {
            EmployeeModel employee = new EmployeeModel();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                string sqlQuery = "SELECT * FROM Emp_Form1 WHERE emp_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    employee.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Profile_Image = rdr["Profile_Image"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = rdr["Salary"].ToString();
                    employee.Start_Date = Convert.ToDateTime(rdr["Start_Date"]);
                    employee.Notes = rdr["Notes"].ToString();
                    employee.RegisteredDate = Convert.ToDateTime(rdr["RegisteredDate"]);
                }
            }
            return employee;
        }
        public void deleteEmployee(EmployeeModel employeemodel)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteEmpForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_id", employeemodel.Emp_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
       

      
      



    }
}
