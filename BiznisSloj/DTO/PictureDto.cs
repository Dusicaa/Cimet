using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sajt.BiznisSloj.DTO
{
    public class PictureDto:BaseDto
    {
        public int PictureId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public  string Text { get; set; }
    }
}