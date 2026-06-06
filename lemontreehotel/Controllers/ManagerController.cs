using lemontreehotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lemontreehotel.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(manager m)
        {
            string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";

            SqlConnection sc = new SqlConnection(path);
            sc.Open();

            ViewData["Status"] = "Connection successful!";

            string insert = "insert into Manager(name ,email,phone,password,branch)values('" + m.name + "',   '" + m.email + "','" + m.phone + "','" + m.password + "','"+m.Branch+"')";

            SqlCommand scom =new SqlCommand(insert, sc);
            scom.ExecuteNonQuery();
            return RedirectToAction("Home","Index");
            //return View();


        }

        
    }
}