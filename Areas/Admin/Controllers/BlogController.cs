using Sajt.BiznisSloj;
using Sajt.BiznisSloj.Operations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sajt.Areas.Admin.Models;
using Sajt.BiznisSloj.DTO;
using Sajt.DataSloj;
using Sajt.Models.Application;

namespace Sajt.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {        OperationManager _manager= OperationManager.Singleton;
        // GET: Admin/Blog
        public ActionResult Index()
        {
            OpBlogBase blog = new OpBlogBase();
            OperationResult result = _manager.executeOperation(blog);
            return View(result.Items as BlogDto[]);
        }

        // GET: Admin/Blog/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Create(BlogViewModel vm)
        {
            if (ModelState.IsValid)
            {
               
                //Smestanje slike na drajv
                string fileName = Guid.NewGuid().ToString() + "_" + vm.Picture.FileName;
                string putanja = Path.Combine(Server.MapPath("~/Content/images"), fileName);

                vm.Picture.SaveAs(putanja);

                BlogDto dto = new BlogDto
                {

                    Name = vm.Name,
                    Date_created = DateTime.Now,
                    Text = vm.Text,
                    User_id = User.Identity.GetUserId(),
                    Picture = new PictureDto
                    {

                        Alt = "blogslika",
                        Src = "Content/Images/" + fileName
                    }


                };

                OpBlogInsert op = new OpBlogInsert();
                op.BlogDto = dto;
                var result = _manager.executeOperation(op);
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }

        // GET: Admin/Blog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Blog/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
