using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSSA.Models;

namespace ProjectSSA.ViewModels
{
    public class ReserveerTicketsVM
    {
        public string Ticketholder { get; set; }
        public string TicketholderEmail { get; set; }
        public int TicketType { get; set; }
        public int Amount { get; set; }
    }
}