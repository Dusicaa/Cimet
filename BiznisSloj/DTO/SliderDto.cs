using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sajt.BiznisSloj.DTO
{
    public class SliderDto:BaseDto
    {
       public  List<PictureDto> Pictures { get; set; }
    }
}