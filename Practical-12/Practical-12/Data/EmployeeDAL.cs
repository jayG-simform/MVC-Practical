using Practical_12.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace Practical_12.Services
{
    public class EmployeeDAL
    {

        public List<Employee> GetUser()
        {
            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<Employee> list = new List<Employee>();
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(new Employee()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                    });
                }
                return list;
            }
        }

        public void DefaultUser()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = $"insert into Employee values('Jay','H','Gohel','2002-08-21','7383751559','Rajkot, Gujrat'),('Jill','P','Patel','2002-04-17','8464877214','Aanand, Gujrat'),('Abhay','J','Chhothani','2002-09-04','8776546787','Gondal, Gujrat')";
                SqlCommand cmd = new SqlCommand(sql,con);
                var res = cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void InsertEmp(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var DOB = $"{emp.DOB.Year}-{emp.DOB.Month}-{emp.DOB.Day}";
                var sql = $"insert into Employee values('{emp.FirstName}','{emp.MiddleName}','{emp.LastName}','{DOB}','{emp.MobileNumber}','{emp.Address}')";
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<Employee> FirstNameToSQL()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                var sql = "Update Employee set FirstName='SQLPerson' where Id=(Select MIN(Id) from Employee);";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<Employee> list = new List<Employee>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Employee()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                    });
                }
                return list;
            }
        }

        public List<Employee> MiddleNameTOI()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                var sql = "Update Employee set MiddleName='l'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<Employee> list = new List<Employee>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Employee()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                    });
                }
                return list;
            }
        }
        public List<Employee> DeleteValue2()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                var sql = "delete from Employee where Id < 2";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<Employee> list = new List<Employee>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Employee()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                    });
                }
                return list;
            }
        }
        public void DeleteAll()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                var sql = "Truncate table Employee";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
    }
}