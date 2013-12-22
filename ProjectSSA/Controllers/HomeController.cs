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
            ViewBag.Message = "Your contact page.";

            //var ViewModel = new List<LineUpVM>();
            var ViewModel = new LineUpVM();

            ViewModel.Dates = LineUpRepository.GetAllDays();

            if (SelectedDate != null)
            {
                
                DateTime DTSelectedDate = Convert.ToDateTime(SelectedDate);
                string DTSelectedDate1 = DTSelectedDate.ToString("yyyy-MM-dd");

                ViewModel.LineUps = LineUpRepository.GetLineUpsByDay(DTSelectedDate1);
                ViewModel.SelectedDate = SelectedDate;

                //foreach (LineUp lineup in daylineups)
                //{
                //    ViewModel.
                //    ViewModelList.Add(new LineUpVM
                //    {
                //        Date = lineup.Date,
                //        Band = lineup.Band,
                //        Stage = lineup.Stage
                //    });
                //}

            }

            return View(ViewModel);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
