using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sajt.BiznisSloj.DTO;

namespace Sajt.Models.Application
{
    public class PocetnaViewModel
    {

        public  SliderDto Slider { get; set; }
        public  List<BlogDto> Blog { get; set; }
        public  List<RecipesDto> Recepti { get; set; }
    }
}