using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JetBrains.Util;
using Sajt.BiznisSloj.DTO;
using Sajt.DataSloj;
using Sajt.Models.Application;

namespace Sajt.BiznisSloj.Operations
{
    public class OpBlogBase : Operation
    {
        public BlogDto BlogDto = new BlogDto();
        public override OperationResult execute(CimetEntities entities)
        {

            IEnumerable<BlogDto> ieBlog =
                from blog in entities.blog
                select new BlogDto
                {
                     //Id=blog.Id,
                     Name=blog.name,
                    Text=blog.text,
                    Date_created=blog.date_created,
                    User_id=blog.user_id,
                    UserName=blog.AspNetUsers.UserName,
                    Picture_id=blog.picture_id,
                    Src=blog.picture.src,
                    Alt=blog.picture.alt
                    
                };

            OperationResult result = new OperationResult();
            result.Items = ieBlog.ToArray();
            result.Status = true;
            return result;
        }
    }

    public class OpBlogInsert : OpBlogBase
    {

        public override OperationResult execute(CimetEntities entities)
        {

            blog blog = new blog();
            blog.name = this.BlogDto.Name;
            blog.text = this.BlogDto.Text;
            blog.date_created = DateTime.Now;
            blog.user_id = this.BlogDto.User_id;
            blog.picture_id = this.BlogDto.Picture.PictureId;
            picture p = new picture
            {   
                src = BlogDto.Picture.Src,
                alt = BlogDto.Picture.Alt
            };          
            
           
            entities.blog.Add(blog);
            entities.SaveChanges();
            return base.execute(entities);

        }
    }
}