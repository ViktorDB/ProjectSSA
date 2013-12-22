using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectSSA.Models;

namespace ProjectSSA.ViewModels
{
    public class LineUpVM
    {
        public List<LineUp> Dates { get; set; }
        public string Date { get; set; }
        public LineUp SelectedLineUp { get; set; }
        public string SelectedDate { get; set; }
        public string Band { get; set; }
        public string Stage { get; set; }
        public List<LineUp> LineUps { get; set; }
    }
}