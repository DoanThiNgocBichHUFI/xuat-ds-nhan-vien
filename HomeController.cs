using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai1.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace bai1.Controllers
{
    public class HomeController : Controller
    {
        
        public string conStr = @"Data Source=DESKTOP-0MNS8CK\MSSQLSERVER01;Initial Catalog=QL_NhanSu;Integrated Security=True";
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowEmployee()
        {
            
            List<Employee> listEmployee = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    string conStr= @"Data Source=DESKTOP-0MNS8CK\SQLEXPRESS;Initial Catalog=QL_NhanSu;Integrated Security=True";
                    con.ConnectionString = conStr;
                    string sql = "select *from tbl_Employee";
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        var emp = new Employee();
                        emp.ID = (int)row["Id"];
                        emp.Name = row["Name"].ToString();
                        emp.Gender= row["Gender"].ToString();
                        emp.City= row["City"].ToString();
                        listEmployee.Add(emp);
                    }
                }
                return View(listEmployee);
            }catch{
                return RedirectToAction("Error","Home");
            }
        }

        
	}
}
