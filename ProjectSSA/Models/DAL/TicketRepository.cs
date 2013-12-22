using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBHelper;
using System.Data.Common;

namespace ProjectSSA.Models.DAL
{
    public class TicketRepository
    {
        public static List<Ticket> GetTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            string sSQL = "SELECT * FROM Ticket INNER JOIN TicketType ON Ticket.TicketType = TicketType.ID";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                Ticket t = new Ticket();

                t.Ticketholder = reader["Ticketholder"].ToString();
                t.TicketholderEmail = reader["TicketholderEmail"].ToString();
                t.TicketName = reader["Name"].ToString();
                t.AvailableTickets = reader["AvailableTickets"].ToString();
                t.Price = reader["Price"].ToString();
                t.Amount = reader["Amount"].ToString();

                tickets.Add(t);
            }
            reader.Close();

            return (tickets);
        }

        public static List<Ticket> GetAvailableTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            string sSQL = "SELECT * FROM TicketType";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                Ticket t = new Ticket();

                t.TicketName = reader["Name"].ToString();
                t.AvailableTickets = reader["AvailableTickets"].ToString();
                t.Price = reader["Price"].ToString();

                tickets.Add(t);
            }
            reader.Close();

            return (tickets);
        }
    }
}