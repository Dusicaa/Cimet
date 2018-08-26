using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sajt.BiznisSloj.DTO;
using Sajt.DataSloj;

namespace Sajt.BiznisSloj.Operations
{
    public class OpGalerijaBase:Operation
    {

        public override OperationResult execute(CimetEntities entities)
        {
            GalleryDto dto = new GalleryDto();
            IEnumerable<PictureDto> iePictures =
                from galerija in entities.gallery
                select new PictureDto
                {
                    Alt = galerija.picture.alt,
                    Src = galerija.picture.src
                };
            dto.Pictures = iePictures.ToList();

            OperationResult result = new OperationResult();
            result.Status = true;
            result.Items = new BaseDto[1];
            result.Items[0] = dto;
            return result;


        }
    }
}