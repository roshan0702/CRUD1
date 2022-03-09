using CRUD1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD1.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        CRUD1Entities CRUDObj = new CRUD1Entities();

        public ActionResult Info(info obj)
        {
            if (obj != null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddInfo(info model)
        {
            if (ModelState.IsValid)
            {
                info obj = new info();
                obj.ID = model.ID;
                obj.Name = model.Name;
                obj.Fname = model.Fname;
                obj.Email = model.Email;
                obj.Mobile = model.Mobile;
                obj.Discription = model.Discription;

                if (model.ID == 0)
                {
                    CRUDObj.info.Add(obj);
                    CRUDObj.SaveChanges();
                }
                else
                {
                    CRUDObj.Entry(obj).State = EntityState.Modified;
                    CRUDObj.SaveChanges();
                }


            }

            ModelState.Clear();

            return View("Info");
        }

        public ActionResult InfoList()
        {
            var InfoResult = CRUDObj.info.ToList();
            return View(InfoResult);
        }

        public ActionResult Delete(int id)
        {
            var InfoDelete = CRUDObj.info.Where(x => x.ID == id).First();
            CRUDObj.info.Remove(InfoDelete);
            CRUDObj.SaveChanges();

            var InfoResult = CRUDObj.info.ToList();

            return View("InfoList",InfoResult);
        }

    }
}