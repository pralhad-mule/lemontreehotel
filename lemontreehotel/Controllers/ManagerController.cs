using lemontreehotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace lemontreehotel.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()//registration
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

            string insert = "insert into Manager(name ,email,phone,password,branch)values('" + m.name + "',   '" + m.email + "','" + m.phone + "','" + m.password + "','" + m.Branch + "')";

            SqlCommand scom = new SqlCommand(insert, sc);
            scom.ExecuteNonQuery();
            return RedirectToAction("Home", "Index");
            //return View();


        }

        public ActionResult managerlogin()
        {
            return View();
        }
/// <summary>
/// ////////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>

                             // dashbord
        public ActionResult managerdashbord()
        {
            string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";

            SqlConnection sc = new SqlConnection(path);
            sc.Open();

            // Total Users
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM users", sc);
            ViewBag.TotalUsers = cmd1.ExecuteScalar();

            // Total Room Bookings
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM roombook", sc);
            ViewBag.TotalBookings = cmd2.ExecuteScalar();

            //Recently booking
            List<Booking> roombook = new List<Booking>();
            SqlCommand cmd3 = new SqlCommand("SELECT TOP 5 * FROM roombook ORDER BY Id DESC", sc);
            SqlDataReader dr = cmd3.ExecuteReader();
            while (dr.Read())
            {
                roombook.Add(new Booking()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    custimername = dr["custimername"].ToString(),
                    roomtype = dr["roomtype"].ToString(),
                    CheckInDate = dr["CheckInDate"].ToString(),
                    CheckOutDate = dr["CheckOutDate"].ToString()
                });

            }

            dr.Close();
            sc.Close();

            return View(roombook);

        }

        public ActionResult User()
        {
            return View();
        }
    }
}