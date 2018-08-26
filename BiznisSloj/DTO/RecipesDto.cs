using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sajt.BiznisSloj.DTO
{
    public class RecipesDto:BaseDto
    {

        public int Id { get; set; }
       // public int picture_id { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public  string Src { get; set; }
        public  string Alt { get; set; }
    }
}