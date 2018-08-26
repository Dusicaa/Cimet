using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sajt.BiznisSloj.DTO
{
    public class AboutDto:BaseDto
    {
        //public int Id { get; set; }
       // public int? Picture_id { get; set; }
       
        public string Text { get; set; }
       public  string Src { get; set; }
       public  string Alt { get; set; }
    }
}