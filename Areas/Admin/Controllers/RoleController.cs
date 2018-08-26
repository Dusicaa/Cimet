using Sajt.BiznisSloj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sajt.BiznisSloj.DTO;
using Sajt.BiznisSloj.Operations;

namespace Sajt.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {

         OperationManager _manager=OperationManager.Singleton;
        [HttpGet]
        public ActionResult Index()
        {
            Operation op = new OpRoleBase();
            var rez = _manager.executeOperation(op);

            return View(rez.Items as RoleDto[]);
        }

        [HttpGet]
        public ActionResult Details(string uuid)
        {
            OpRoleBase op = new OpRoleBase();
            op.criteria.Uuid = uuid;
            var result = _manager.executeOperation(op);
            RoleDto dto = result.Items[0] as RoleDto;
            return View(dto);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Create(RoleDto dto)
        {
            try
            {
                OpRoleInsert op = new OpRoleInsert();
                op.Role = dto;
                op.Role.Uuid = Guid.NewGuid().ToString();
                OperationResult rez = _manager.executeOperation(op);
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(string uuid)
        {
            OpRoleBase editView = new OpRoleBase();
            editView.criteria.Uuid = uuid;
            OperationResult rez = _manager.executeOperation(editView);
            RoleDto dto = rez.Items[0] as RoleDto;
            return View(dto);
        }

     
        [HttpPost]
        public ActionResult Edit( RoleDto role)
        {
            try
            {
                OpRoleUpdate update = new OpRoleUpdate();
                update.Role = role;
                OperationResult result = _manager.executeOperation(update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        [HttpGet]
        // GET: Admin/Role/Delete/5
        public ActionResult Delete(string uuid)
        {
            OpRoleDelete delete = new OpRoleDelete();
            delete.Uuid = uuid;
            OperationResult rez = _manager.executeOperation(delete);
            return RedirectToAction("Index");
        }

       
    }
}
