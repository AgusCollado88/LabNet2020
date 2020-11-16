using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaMVC.Models
{
    public class BBCharacters
    {
        public int char_id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        //public IList<string> occupation { get; set; }
        public string img { get; set; }
        public string status { get; set; }
        public string nickname { get; set; }
        public IList<int> appearance { get; set; }
        public string portrayed { get; set; }
        public string category { get; set; }
       // public IList<int> better_call_saul_appearance { get; set; }
    }

}
