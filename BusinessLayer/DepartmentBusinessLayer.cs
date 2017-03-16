using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public  class DepartmentBusinessLayer
    {
        public IEnumerable<Departments> Departments
        {
            get
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
                List<Departments> departments = new List<Departments>();

                using (SqlConnection con = new SqlConnection(connectionstring)) {

                    SqlCommand cmd = new SqlCommand("spGetDepartments", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read()) {

                        Departments dep = new Departments();

                        dep.ID = Convert.ToInt32(rdr["ID"]);
                        dep.Name = rdr["Name"].ToString();

                        departments.Add(dep);

                    }
                }

                return (departments);
            }
        }
    }
}
