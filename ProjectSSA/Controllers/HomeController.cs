using ProjectSSA.Models;
using ProjectSSA.Models.DAL;
using ProjectSSA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSSA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Bands()
        {
            ViewBag.Message = "Een overzicht van alle bands op het festival.";

            var ViewModel = new List<BandsVM>();

            var Bands = BandRepository.GetBands();
            foreach (Band band in Bands)
            {
                ViewModel.Add(new BandsVM
                {
                    ID = band.ID,
                    Name = band.Name,
                    Picture = band.Picture
                });
            }

            return View(ViewModel);
        }

        public ActionResult Details(int id)
        {
            //var ViewModel = new BandDetailsVM();

            var Band = BandRepository.GetBandDetails(id);
            BandDetailsVM ViewModel = new BandDetailsVM();

            ViewModel.ID = Band.ID;
            ViewModel.Name = Band.Name;
            ViewModel.Picture = Band.Picture;
            ViewModel.Description = Band.Description;
            ViewModel.Facebook = Band.Facebook;
            ViewModel.Twitter = Band.Twitter;
            ViewModel.Genres = Band.Genres;

            return View(ViewModel);
        }

        public ActionResult LineUp(string SelectedDate)
        {
            ViewBag.Message = "De Line Up.";

            var ViewModel = new LineUpVM();

            ViewModel.Dates = LineUpRepository.GetAllDays();

            if (SelectedDate != null)
            {
                
                DateTime DTSelectedDate = Convert.ToDateTime(SelectedDate);
                string DTSelectedDate1 = DTSelectedDate.ToString("yyyy-MM-dd");

                ViewModel.LineUps = LineUpRepository.GetLineUpsByDay(DTSelectedDate1);
                ViewModel.SelectedDate = SelectedDate;
            }

            return View(ViewModel);

        }

        public ActionResult Overzicht()
        {
            ViewBag.Message = "Een overzicht van gereserveerde tickets.";

            var ViewModel = new OverzichtVM();
            ViewModel.Tickets = TicketRepository.GetTickets();
            ViewModel.AvailableTickets = TicketRepository.GetAvailableTickets();

            return View(ViewModel);
        }

        public ActionResult Tickets()
        {
            ViewBag.Message = "Reserveer je tickets.";

            var ViewModel = new ReserveerTicketsVM();
            ViewModel.TicketTypeCombo = TicketRepository.GetTicketTypes();
            
            return View(ViewModel);
        }

        public ActionResult ConfirmReservation(Ticket ticket)
        {
            string ticketnaam =  TicketRepository.GetTicketName(ticket.ID);
            var ViewModel = new ReserveerTicketsVM();
            ViewModel.TicketName = ticketnaam;
            ViewModel.Ticketholder = ticket.Ticketholder;
            ViewModel.TicketholderEmail = ticket.TicketholderEmail;
            ViewModel.ID = ticket.ID;
            ViewModel.Amount = ticket.Amount;

            return View(ViewModel);
        }

        public ActionResult ConfirmReservationOK(Ticket ticket)
        {
            TicketRepository.ReserveerTicket(ticket);


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
