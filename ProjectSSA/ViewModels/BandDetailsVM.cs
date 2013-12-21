using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSSA.ViewModels
{
    public class BandDetailsVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public int Genres { get; set; }
    }
}