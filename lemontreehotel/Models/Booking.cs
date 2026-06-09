using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lemontreehotel.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string custimername { get; set; }
        public string email { get; set; }
        public string phone { get; set; }

        public string roomtype { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int NumberOfGuests { get; set; }

        public decimal PricePerNight { get; set; }


    }
}