using ProjectSSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSSA.ViewModels
{
    public class OverzichtVM
    {
        public List<Ticket> Tickets { get; set; }
        public List<Ticket> AvailableTickets { get; set; }

        public string Ticketholder { get; set; }
        public string TicketholderEmail { get; set; }
        public string TicketName { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }
    }
}