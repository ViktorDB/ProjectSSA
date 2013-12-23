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

                t.ID = int.Parse(reader["ID"].ToString());
                t.TicketName = reader["Name"].ToString();
                t.AvailableTickets = reader["AvailableTickets"].ToString();
                t.Price = reader["Price"].ToString();

                tickets.Add(t);
            }
            reader.Close();

            return (tickets);
        }

        public static List<TicketType> GetTicketTypes()
        {
            List<TicketType> tickets = new List<TicketType>();
            string sSQL = "SELECT * FROM TicketType";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                TicketType t = new TicketType();

                t.ID = int.Parse(reader["ID"].ToString());
                t.Name = reader["Name"].ToString();
                t.AvailableTickets = int.Parse(reader["AvailableTickets"].ToString());
                t.Price = int.Parse(reader["Price"].ToString());

                tickets.Add(t);
            }
            reader.Close();

            return (tickets);
        }

        public static String GetTicketName(int id)
        {
            string sSQL = string.Format("SELECT Name FROM TicketType WHERE ID = {0}", id);
            string name = "";

            DbDataReader reader = Database.GetData(sSQL);
            while (reader.Read())
            {
                name = reader["Name"].ToString();
            }
            reader.Close();

            return (name);
        }

        public static String ReserveerTicket(Ticket ticket)
        {
            string sSQL = string.Format("INSERT INTO Ticket (Ticketholder, TicketholderEmail, TicketType, Amount) VALUES ('{0}','{1}','{2}','{3}')", ticket.Ticketholder, ticket.TicketholderEmail, ticket.ID, ticket.Amount);

            DbDataReader reader = Database.GetData(sSQL);

            return (sSQL);
        }


    }
}