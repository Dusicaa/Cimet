using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Sajt.BiznisSloj.DTO;
using Sajt.DataSloj;

namespace Sajt.BiznisSloj.Operations
{
    public class  PictureCriteria : SelectCriteria
    {

       
    }


    public class OpPictureBase : Operation
    {
        public PictureDto Slika = new PictureDto();
        public PictureCriteria criteria = new PictureCriteria();



        public override OperationResult execute(CimetEntities entities)
        {
            IEnumerable<PictureDto> iePicture =
                from slika in entities.picture
                select new PictureDto
                {
                    PictureId =slika.picture_id,
                   Src=slika.src,
                    Alt=slika.alt                 

                };
            //ovde prosirujemo upit
            if (!(criteria.Id<0 || criteria.Id==0 || criteria.Id==null))
            {
                iePicture = iePicture.Where(r => r.PictureId == criteria.Id);

            }


            OperationResult result = new OperationResult();
            result.Items = iePicture.ToArray();
            result.Status = true;
            return result;
        }
    }

    public class OpPictureInsert: OpPictureBase
    {
        public override OperationResult execute(CimetEntities entities)
        {


            picture slika = new picture();
            slika.src = this.Slika.Src;
            slika.picture_id = this.Slika.PictureId;
            slika.alt = this.Slika.Alt;
            entities.picture.Add(slika);
            entities.SaveChanges();
            return base.execute(entities);
        }
    }

    public class OpPictureDelete: OpPictureBase
    {
        public int Id { get; set; }
        public override OperationResult execute(CimetEntities entities)
        {

            base.criteria.Id = Id;
            picture slika = entities.picture.Where(r => r.picture_id== Id).FirstOrDefault();
            if (slika != null)
            {

                entities.picture.Remove(slika);
                entities.SaveChanges();
                return base.execute(entities);
            }
            else
            {

                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "Slika ne postoji !";
                return result;
            }
        }
    }

    public class OpPictureUpdate : OpPictureBase
    {

        public override OperationResult execute(CimetEntities entities)
        {
            picture slika = entities.picture.Where(r => r.picture_id == Slika.PictureId).FirstOrDefault();
            if (slika != null)
            {
                slika.src = Slika.Src;
                slika.alt = Slika.Alt;
                entities.SaveChanges();
                return base.execute(entities);
            }

            OperationResult result = new OperationResult();
            result.Status = false;
            result.Message = "Slika ne postoji.";
            return result;


        }
    }
}