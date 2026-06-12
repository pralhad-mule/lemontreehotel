using lemontreehotel.Models;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace lemontreehotel.Controllers
{
    public class RoomsController : Controller
    {
        public ActionResult Room()
        {
            return View();
        }

/// ///////////////////////////////////////////////////////////////////////////////////////////////
    
        public ActionResult view_details_standard()
        {
            return View();
        }

        public ActionResult view_details_delux()
        {
            return View();
        }
        public ActionResult view_details_superdelux()
        {
            return View();
        }
        public ActionResult view_details_family()
        {
            return View();
        }
        public ActionResult view_details_president()
        {
            return View();
        }
        public ActionResult view_details_metting()
        {
            return View();
        }
        public ActionResult view_details_executative()
        {
            return View();
        }
        public ActionResult view_details_premium()
        {
            return View();
        }
        public ActionResult view_details_luxary()
        {
            return View();
        }
        public ActionResult view_details_business()
        {
            return View();
        }


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //boooking the room
        public ActionResult book_room()
        {
            return View();
        }

        [HttpPost]

        public ActionResult book_room(Booking b)
        {
;
        
            string path = "Data Source=pralhad\\SQLEXPRESS;Initial Catalog=ItHotel;Integrated Security=True";
             SqlConnection sc=new SqlConnection(path);
            sc.Open();

            ViewData["status"] = "Booksuccessfully successfully";

            string insert = "insert into roombook(custimername,email,phone,roomtype,CheckInDate,CheckOutDate,Guests,Price_Per_Nigh,TotalPrice )" +
                " values('"+b.custimername+"','"+ b.email+"' , '"+ b.phone+"' ,'"+ b.roomtype+"' , '"+ b .CheckInDate+"' , '"+ b. CheckOutDate+"' , '"+b.Guests+"','"+ b.Price_Per_Nigh+"' ,'"+b. TotalPrice + "')";
            SqlCommand scom = new SqlCommand(insert, sc);
            scom.ExecuteNonQuery();


            return View();
        }

    }
}