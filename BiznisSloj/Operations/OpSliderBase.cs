using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sajt.BiznisSloj.DTO;
using Sajt.DataSloj;

namespace Sajt.BiznisSloj.Operations
{
    public class OpSliderBase:Operation
    {
        public override OperationResult execute(CimetEntities entities)
        {
            SliderDto dto = new SliderDto();
            IEnumerable<PictureDto> iePictures =
                from slider in entities.slider
                select new PictureDto
                {
                      Alt = slider.picture.alt,
                     Src = slider.picture.src,
                    Text=slider.text
                   
                };
            dto.Pictures = iePictures.ToList();

            OperationResult result=new OperationResult();
            result.Status = true;
            result.Items = new BaseDto[1];
            result.Items[0] = dto;
            return result;


        }
    }
}