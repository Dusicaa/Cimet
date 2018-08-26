using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sajt.Areas.Admin.Models
{
    public class PictureViewModel
    {

        [ValidateImage(ErrorMessage = "Slika nije odgovarajuceg tipa ili je veca od 1mb.")]
        public HttpPostedFileBase Picture { get; set; }
    }
}