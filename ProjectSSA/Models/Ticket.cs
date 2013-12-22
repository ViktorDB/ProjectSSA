using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSSA.Models
{
    public class Ticket
    {
        public string Ticketholder { get; set; }
        public string TicketholderEmail { get; set; }
        public string TicketName { get; set; }
        public string Price { get; set; }
        public string AvailableTickets { get; set; }
        public string Amount { get; set; }
    }
}