using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sajt.DataSloj;
using Sajt.Models.Application;

namespace Sajt.BiznisSloj.DTO
{
    public class BlogDto:BaseDto
    {


        public int Id { get; set; }
        public string User_id { get; set; }
        public string UserName { get; set; }
        public int? Picture_id { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime? Date_created { get; set; }

        //public virtual List<comments> Comments { get; set; }

        // public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual picture picture { get; set; }
        public PictureDto Picture { get;set; }
    }
}