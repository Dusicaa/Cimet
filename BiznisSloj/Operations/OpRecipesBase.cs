using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sajt.BiznisSloj.DTO;
using Sajt.DataSloj;

namespace Sajt.BiznisSloj.Operations
{
    public class OpRecipesBase:Operation
    {
        public override OperationResult execute(CimetEntities entities)
        {
            IEnumerable<RecipesDto> ieRecepti =
                from recept in entities.recipes
                select new RecipesDto
                {
                      Name   = recept.name,
                     Alt=recept.picture.alt,
                    Src=recept.picture.src,
                      Text=recept.text
                     

                };

            OperationResult result = new OperationResult();
            result.Items = ieRecepti.ToArray();
            result.Status = true;
            return result;
        }
    }
}