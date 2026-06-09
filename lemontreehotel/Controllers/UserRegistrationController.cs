using lemontreehotel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace lemontreehotel.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistration
        public ActionResult UserReg()
        {
            return View();
        }
        [HttpPost]

        public ActionResult UserReg(userRegister k)
        {
            //validation
            if (string.IsNullOrWhiteSpace(k.name) ||
                string.IsNullOrWhiteSpace(k.email) ||
                string.IsNullOrWhiteSpace(k.mobile_no) ||
                string.IsNullOrWhiteSpace(k.gender) ||
                string.IsNullOrWhiteSpace(k.password))
            {
                ViewData["status"] = "❌ Please fill all required fields!";
                return View();
            }

            // 🔴 Mobile validation (10 digits only)
            if (k.mobile_no.Length == 10 && k.mobile_no.All(char.IsDigit))
            {
                // valid mobile number → allow insert
            }
            else
            {
                ViewData["status"] = "❌ Mobile number must be exactly 10 digits!";
                return View();
            }

            if (k.password != k.confirm_password)
            {
                ViewData["status"] = "❌ Password does not match!";

            }
            else
            {
                ViewData["status"] = "❌ Password is match!";
            }
            // Database connection
            string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";
            SqlConnection sc = new SqlConnection(path);
            sc.Open();
            ViewData["status"] = "connection successfully....";

            string insert = "insert into users(name,email,mobile_no,gender,date_of_birth,address,password,confirm_password)values('" + k.name + "' , '" + k.email + "','" + k.mobile_no + "', '" + k.gender + "' , '" + k.Date_of_birth + "' , '" + k.address + "' , '" + k.password + "' , '" + k.confirm_password + "' )";
            SqlCommand scom = new SqlCommand(insert, sc);
            scom.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult userlogin()
        {
            return View();
        }



        [HttpPost]


        public ActionResult userlogin(string email, string password)
        {

            string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";
            SqlConnection sc = new SqlConnection(path);

            string querry = "select * from users where email=@email AND password=@password";
            SqlCommand cmd = new SqlCommand(querry, sc);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            sc.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid Email or Password";
            }

            sc.Close();
            return View();  

        }

        
    }
}
    

     
            
    