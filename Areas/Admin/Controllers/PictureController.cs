using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Sajt.Areas.Admin.Models;
using Sajt.BiznisSloj;
using Sajt.BiznisSloj.DTO;
using Sajt.BiznisSloj.Operations;

namespace Sajt.Areas.Admin.Controllers
{
    public class PictureController : Controller
    {
        OperationManager _manager = OperationManager.Singleton;


        [HttpGet]
        public ActionResult Index()
        {
            Operation op = new OpPictureBase();
            var rez = _manager.executeOperation(op);

            return View(rez.Items as PictureDto[]);
            
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            OpPictureBase op = new OpPictureBase();
            op.criteria.Id = id;
            var result = _manager.executeOperation(op);
            PictureDto dto = result.Items[0] as PictureDto;
            return View(dto);
        }

        [HttpGet]
        public ActionResult Create()
        {
           
                return View();
           
        }

     
        [HttpPost]
        public ActionResult Create(PictureViewModel vm)
        {
            try
            {   
                
                //Smestanje slike na drajv
                string fileName = Guid.NewGuid().ToString() + "_" + vm.Picture.FileName;
                string putanja = Path.Combine(Server.MapPath("~/Content/images"), fileName);

                vm.Picture.SaveAs(putanja);

                PictureDto dto = new PictureDto
                {
                    Alt = "slikaaaa",
                    Src = "Content/images/" + fileName

                };


                OpPictureInsert op = new OpPictureInsert();
                op.Slika = dto;              
                OperationResult rez = _manager.executeOperation(op);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

       [HttpGet]
        public ActionResult Edit(int id)
        {
            OpPictureBase editView = new OpPictureBase();
            editView.criteria.Id = id;
            OperationResult rez = _manager.executeOperation(editView);
            PictureDto dto = rez.Items[0] as PictureDto;
            return View(dto);
        }

     
        [HttpPost]
        public ActionResult Edit( PictureDto dto)
        {
            try
            {
                OpPictureUpdate update = new OpPictureUpdate();
                update.Slika = dto;
                OperationResult result = _manager.executeOperation(update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            OpPictureDelete delete = new OpPictureDelete();
            delete.Id = id;
            OperationResult rez = _manager.executeOperation(delete);
            return RedirectToAction("Index");
        }

        // POST: Admin/Picture/Delete/5
       
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
