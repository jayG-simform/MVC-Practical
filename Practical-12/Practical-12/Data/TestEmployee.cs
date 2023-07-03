using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Practical_12.Models;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace Practical_12.Services
{
    public class TestEmployee
    {
        public List<Test3_Employee> GetUser()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employee_Test3", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                List<Test3_Employee> list = new List<Test3_Employee>();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Test3_Employee()
                    {
                        Id = (int)dr["Id"],
                        FirstName = dr["FirstName"].ToString(),
                        MiddleName = dr["MiddleName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = (DateTime)dr["DOB"],
                        MobileNumber = dr["MobileNumber"].ToString(),
                        Address = dr["Address"].ToString(),
                        Salary = (decimal)dr["Salary"],
                        DesignationId = (int)dr["DesignationId"]
                    });
                }
                return list;
            }
        }
        public void InsertDesignation()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = $"insert into Designation values('Senior Engineer'),('Junior Engineer'),('Trainee'),('Team Lead')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void InsertEmployee()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = $"insert into Employee_Test3 values('Jay','J','Kosti','21-05-2002','5454821215','Ahemdabad, Gujrat','45000','2'),('Bhavin','H','Karelia','12-04-2001','5454821215','Rajkot, Gujrat','54000','1')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<CountEmpByDesination> CountEmpByDesignation()
        {
            List<CountEmpByDesination> designationHavingMoreThan1Employee = new List<CountEmpByDesination>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();

                string Sql = "select Designation,COUNT(*) as count from Employee_Test3 e join Designation d on e.DesignationId = d.Id group by Designation";
                SqlCommand cmd = new SqlCommand(Sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CountEmpByDesination result = new CountEmpByDesination()
                    {
                        Designation = (string)reader["Designation"],
                        Count = (int)reader["count"]
                    };

                    designationHavingMoreThan1Employee.Add(result);
                }
                return designationHavingMoreThan1Employee;
            }
        }
        public List<CountEmpByDesination> DisplayEmployess()
        {
            List<CountEmpByDesination> employeeWithDesignationModels = new List<CountEmpByDesination>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                string sql = "Select FirstName, MiddleName, LastName, d.Designation from Employee_Test3 e Inner join Designation d on e.DesignationId = d.Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CountEmpByDesination employee = new CountEmpByDesination()
                    {
                        FirstName = (string)reader["First Name"],
                        MiddleName = (reader["Middle Name"] ?? "NA") as string,
                        LastName = (string)reader["Last Name"],
                        Designation = (string)reader["Designation"]
                    };

                    employeeWithDesignationModels.Add(employee);
                }
                return employeeWithDesignationModels;
            }
        }
        public List<CountEmpByDesination> Query3()
        {
            List<CountEmpByDesination> employeeWithDesignationModels = new List<CountEmpByDesination>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                string sql = "Select FirstName, MiddleName, LastName, d.Designation from Employee_Test3 e Inner join Designation d on e.DesignationId = d.Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CountEmpByDesination employee = new CountEmpByDesination()
                    {
                        FirstName = (string)reader["FirstName"],
                        MiddleName = (reader["MiddleName"] ?? "NA") as string,
                        LastName = (string)reader["LastName"],
                        Designation = (string)reader["Designation"]
                    };

                    employeeWithDesignationModels.Add(employee);
                }
                return employeeWithDesignationModels;
            }
        }
        public List<CountEmpByDesination> FetchTheEmployeePerDesignations() 
        {
            List<CountEmpByDesination> employeeWithDesignationModels = new List<CountEmpByDesination>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                string sql = "select * from EmployeeView";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CountEmpByDesination employee = new CountEmpByDesination()
                    {
                        FirstName = (string)reader["FirstName"],
                        MiddleName = (reader["MiddleName"] ?? "NA") as string,
                        LastName = (string)reader["LastName"],
                        Designation = (string)reader["Designation"],
                        DOB = (DateTime)reader["DOB"],
                        MobileNumber = reader["MobileNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Salary = (decimal)reader["Salary"]
                    };

                    employeeWithDesignationModels.Add(employee);
                }
                return employeeWithDesignationModels;
            }
        }
        public void CreateView()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                string sql = "CREATE VIEW EmployeeView AS SELECT e.Id, FirstName, MiddleName, LastName, Designation, DOB, MobileNumber, Address, Salary FROM Employee_Test3 e Inner join Designation d on e.DesignationId = d.Id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void CreateTheStoreProcedureForInsertInDesignationTable()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = @"create procedure InsertDesignation 
                                Designation varchar(50) 
                                as begin 
                                Insert into Designation values(Designation) 
                            end";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void CreateTheStoreProcedureForInsertInEmployeeTable()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = @"create procedure InsertEmployee
	                            @FirstName varchar(50),
	                            @MiddleName varchar(50),
	                            @LastName varchar(50),
	                            @DOB date,
	                            @MobileNumber varchar(10),
	                            @Address varchar(100),
	                            @Salary decimal(10,2),
	                            @DesignationID varchar(50)
                            as
                            begin
	                            Insert into Employee_Test3 values(@FirstName,@MiddleName,@LastName,@DOB,@MobileNumber,@Address,@Salary,@DesignationID) 
                            end ";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<CountEmpByDesination> DesignationWhichHaveMoreThanOneEmployee()
        {
            List<CountEmpByDesination> employeeWithDesignationModels = new List<CountEmpByDesination>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                string sql = @"SELECT d.Designation,  [Employee Count] = COUNT(e.Id)
                                FROM Employee_Test3 e
                                INNER JOIN Designation d ON e.DesignationId = d.Id
                                GROUP BY d.Designation HAVING COUNT(e.Id) > 1;";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CountEmpByDesination employee = new CountEmpByDesination()
                    {
                        Designation = (string)reader["Designation"],
                        Count = (int)reader["Employee Count"]
                    };

                    employeeWithDesignationModels.Add(employee);
                }
                return employeeWithDesignationModels;
            }
        }
        public List<CountEmpByDesination> CreateStoredProcedureAndWhichGivesSortDatabyDOB()
        {
            List<CountEmpByDesination> employeeWithDesignationModels = new List<CountEmpByDesination>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ListOfEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CountEmpByDesination employee = new CountEmpByDesination()
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        MiddleName = (reader["MiddleName"] ?? "NA") as string,
                        LastName = (string)reader["LastName"],
                        Designation = (string)reader["Designation"],
                        DOB = (DateTime)reader["DOB"],
                        MobileNumber = reader["MobileNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Salary = (decimal)reader["Salary"]
                    };

                    employeeWithDesignationModels.Add(employee);
                }
                return employeeWithDesignationModels;
            }
        }
        public List<CountEmpByDesination> CreateStoredProcedureAndWhichGivesSortDatabyFirstName()
        {
            List<CountEmpByDesination> employeeWithDesignationModels = new List<CountEmpByDesination>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getEmployeeDetailsByDesignationId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DesignationId",2);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CountEmpByDesination employee = new CountEmpByDesination()
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        MiddleName = (reader["MiddleName"] ?? "NA") as string,
                        LastName = (string)reader["LastName"],
                        Designation = (string)reader["Designation"],
                        DOB = (DateTime)reader["DOB"],
                        MobileNumber = reader["MobileNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Salary = (decimal)reader["Salary"]
                    };

                    employeeWithDesignationModels.Add(employee);
                }
                return employeeWithDesignationModels;
            }
        }
        public void CreateClustredIndex()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                string sql = @"CREATE NONCLUSTERED INDEX Employee_DesignationId
                                ON Employee_Test3 (DesignationId);";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<CountEmpByDesination> EmployeeMaxSalary()
        {
            List<CountEmpByDesination> employeeWithDesignationModels = new List<CountEmpByDesination>();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Employe"].ConnectionString))
            {
                con.Open();
                var sql = @"SELECT e.Id, FirstName, MiddleName, LastName, Designation, DOB, MobileNumber, Address, Salary
                            FROM Employee_Test3 e
                            join Designation d
                            on e.DesignationId = d.Id
                            WHERE Salary = (
                                SELECT MAX(Salary)
                                FROM Employee_Test3
                            );";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CountEmpByDesination employee = new CountEmpByDesination()
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        MiddleName = (reader["MiddleName"] ?? "NA") as string,
                        LastName = (string)reader["LastName"],
                        Designation = (string)reader["Designation"],
                        DOB = (DateTime)reader["DOB"],
                        MobileNumber = reader["MobileNumber"].ToString(),
                        Address = reader["Address"].ToString(),
                        Salary = (decimal)reader["Salary"]
                    };

                    employeeWithDesignationModels.Add(employee);
                }
                return employeeWithDesignationModels;
            }
        }
    }
}