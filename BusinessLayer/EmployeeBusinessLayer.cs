using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;  //1- define the conn string to the DB
                List<Employee> employees = new List<Employee>();                                           //2- create al list to be populated with the DB rows  

                using (SqlConnection con = new SqlConnection(connectionstring))                           //3- Define a SqL connection to the DB
                {

                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);                            //4-Define SQL Commend to exec the sp
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();                                                                            //5- Open the connection             

                    SqlDataReader rdr = cmd.ExecuteReader();                                             //6- Define a SqlDataReader to start reading the rows data 
                    while (rdr.Read())                                                                //7- while loop to fill an obj of type employee with the row data
                    {
                        Employee emp = new Employee();
                        emp.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                        emp.DepartementId = Convert.ToInt32(rdr["DepartementId"]);
                        emp.Name = rdr["Name"].ToString();
                        emp.Gender = rdr["Gender"].ToString();
                        emp.City = rdr["City"].ToString();

                        employees.Add(emp);                                                         //8- Add the obj to the List 
                    }
                }
                return employees;
            }

        }

        public void AddEmployee(Employee emp)
        {

            string connectionstring = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;  //1- define the conn string to the DB

            using (SqlConnection con = new SqlConnection(connectionstring))
            {                         //3- Define a SqL connection to the DB

                SqlCommand cmd = new SqlCommand("spAddEmployee", con);                            //4-Define SQL Commend to exec the sp
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = emp.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = emp.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = emp.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDepId = new SqlParameter();
                paramDepId.ParameterName = "@DepartementId";
                paramDepId.Value = emp.DepartementId;
                cmd.Parameters.Add(paramDepId);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void SaveEmployee(Employee emp)
        {

            string connectionstring = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;  //1- define the conn string to the DB

            using (SqlConnection con = new SqlConnection(connectionstring))
            {                         //3- Define a SqL connection to the DB

                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);                            //4-Define SQL Commend to exec the sp
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = emp.EmployeeId;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = emp.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = emp.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = emp.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDepId = new SqlParameter();
                paramDepId.ParameterName = "@DepartementId";
                paramDepId.Value = emp.DepartementId;
                cmd.Parameters.Add(paramDepId);

                con.Open();
                cmd.ExecuteNonQuery();

            }


        }

        public void DeleteEmployee(int ID)
        {

            string connectionstring = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {

                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@ID";
                paramID.Value = ID;
                cmd.Parameters.Add(paramID);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}