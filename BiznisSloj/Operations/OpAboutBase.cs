using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sajt.BiznisSloj.DTO;
using Sajt.DataSloj;

namespace Sajt.BiznisSloj.Operations
{
    public class OpAboutBase:Operation
    {

        public AboutDto dto { get; set; }
        public override OperationResult execute(CimetEntities entities)
        {
           
            IEnumerable<AboutDto> ieAbout =
                from about in entities.about
                select new AboutDto
                {  
                   Alt = about.picture.alt,
                    Src = about.picture.src,
                    Text = about.text
                };

          
           
            OperationResult op = new OperationResult();
            op.Status = true;
            op.Items=ieAbout.ToArray();
            //op.Items = new BaseDto[1];
            //op.Items[0] = ieAbout as AboutDto;          
            return op;

        }
    }
}