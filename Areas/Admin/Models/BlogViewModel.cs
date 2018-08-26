using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using Sajt.DataSloj;
using Xunit;

namespace Sajt.Areas.Admin.Models
{
    public class BlogViewModel
    {

        [ValidateImage(ErrorMessage = "Slika nije odgovarajuceg tipa ili je veca od 1mb.")]
        public HttpPostedFileBase Picture { get; set; }

        [Required]
        [DisplayName(" Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
  

     

    }

    public class ValidateImageAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            if (file.ContentLength > 1 * 1024 * 1024)
            {
                return false;
            }

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return img.RawFormat.Equals(ImageFormat.Png) || img.RawFormat.Equals(ImageFormat.Jpeg) || img.RawFormat.Equals(ImageFormat.Gif);
                }
            }
            catch { }
            return false;
        }
    }
}