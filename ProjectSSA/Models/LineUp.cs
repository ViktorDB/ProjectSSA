using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSSA.Models
{
    public class LineUp
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string From { get; set; }
        public string Until { get; set; }
        public string Stage { get; set; }
        public int StageID { get; set; }
        public string Band { get; set; }
        public int BandID { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }

    }
}