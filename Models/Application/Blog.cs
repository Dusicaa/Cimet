using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sajt.Models.Application
{
    public class Blog
    {

        public int Picture_id { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date_created { get; set; }
    }
}