using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSSA.Models
{
    public class TicketType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int AvailableTickets { get; set; }
    }
}