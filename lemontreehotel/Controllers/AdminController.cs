using lemontreehotel.Models;
using System;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace lemontreehotel.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Adminlogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adminlogin(string n, string p)
        {
            if (n.Equals("pralhad@2507") && p.Equals("Mule@123"))
            {
                return RedirectToAction("admindashbord", "Admin");
            }
            else
            {
                ViewBag.s = "Login Unsuccessful";
                return View();
            }
        }

        public ActionResult admindashbord()
        {
            return View();
        }

        public ActionResult Manage_Managers()
        {
            return View();
        }

        public ActionResult Add_Manager()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add_Manager(manager m)
        {

                string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";

                SqlConnection sc = new SqlConnection(path);
                sc.Open();

                string insert = "insert into Manager(name,email,phone,password,branch) " +
                                "values('" + m.name + "','" + m.email + "','" + m.phone + "','" + m.password + "','" + m.Branch + "')";

                SqlCommand cmd = new SqlCommand(insert, sc);

                cmd.ExecuteNonQuery();

                sc.Close();

                ViewData["status"] = "Manager Added Successfully";

                return View();

             
        }

        public ActionResult editmanager(int id)
        {
            manager m = new manager();

            string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";

            SqlConnection sc = new SqlConnection(path);

            sc.Open();

            string query = "select * from Manager where id=" + id;

            SqlCommand cmd = new SqlCommand(query, sc);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                m.id = Convert.ToInt32(reader["id"]);
                m.name = reader["name"].ToString();
                m.email = reader["email"].ToString();
                m.phone = reader["phone"].ToString();
                m.password = reader["password"].ToString();
                m.Branch = reader["branch"].ToString();
            }

            sc.Close();

            return View(m);
        }

        [HttpPost]
        public ActionResult editmanager(manager m)
        {
            string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";

            SqlConnection sc = new SqlConnection(path);

            sc.Open();

            string update = "update Manager set " +
                            "name='" + m.name + "'," +
                            "email='" + m.email + "'," +
                            "phone='" + m.phone + "'," +
                            "password='" + m.password + "'," +
                            "branch='" + m.Branch + "' " +
                            "where id=" + m.id;

            SqlCommand cmd = new SqlCommand(update, sc);

            cmd.ExecuteNonQuery();

            sc.Close();

            return RedirectToAction("Manage_Managers");
        }

        public ActionResult deletemanager(int id)
        {
            string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";

            SqlConnection sc = new SqlConnection(path);

            sc.Open();

            string delete = "delete from Manager where id=" + id;

            SqlCommand cmd = new SqlCommand(delete, sc);

            cmd.ExecuteNonQuery();

            sc.Close();

            return RedirectToAction("Manage_Managers");
        }




        public ActionResult Manage_user()
        {
            return View();
        }
    }
    
}
    
