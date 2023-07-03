using Practical_12.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Practical_12.Services
{
    public class TestEmp
    {
        public List<Test2> GetUser()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee_Test2", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<Test2> list = new List<Test2>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Test2()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                        Salary = (decimal)dr["Salary"]
                    });
                }
                return list;
            }
        }
        public void InsertEmp(Test2 emp)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var DOB = $"{emp.DOB.Year}-{emp.DOB.Month}-{emp.DOB.Day}";
                var sql = $"insert into Employee_Test2 values('{emp.FirstName}','{emp.MiddleName}','{emp.LastName}','{DOB}','{emp.MobileNumber}','{emp.Address}','{emp.Salary}')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DefaultUser()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = $"insert into Employee_Test2 values('Jay','H','Gohel','2002-08-21','7383751559','Rajkot, Gujrat','50000'),('Jill',NULL,'Patel','2002-04-17','8464877214','Aanand, Gujrat','40000'),('Abhay',NULL,'Chhothani','2002-09-04','8776546787','Gondal, Gujrat','40000'),('Bhavin','A','Karelia','2002-06-13','8776546787','Rajkot, Gujrat','80000')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public decimal TotalSalary()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = "select sum(salary) as salary from Employee_Test2";
                SqlCommand cmd = new SqlCommand(sql, con);
                var res = cmd.ExecuteScalar();
                con.Close();
                return (decimal)res;
            }
        }
        public List<Test2> FindEmp()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Employee_Test2 where DOB < '2000-01-01'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<Test2> list = new List<Test2>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Test2()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                        Salary = (decimal)dr["Salary"]
                    });
                }
                return list;
            }
        }
        public int MiddleNameNull()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = "select count(*) as Count from Employee_Test2 where MiddleName is null";
                SqlCommand cmd = new SqlCommand(sql, con);
                var res = cmd.ExecuteScalar();
                con.Close();
                return (int)res;
            }
        }
    }
}