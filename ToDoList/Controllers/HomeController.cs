using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //[HttpPost]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Index()
          {
            Schrdule_dbEntities1 db = new Schrdule_dbEntities1();
            List<Rem_tb> schedule = db.Rem_tb.ToList();
            return View(schedule);
        }

        public ActionResult Delete(int id)
        {
            Schrdule_dbEntities1 db = new Schrdule_dbEntities1();
            Rem_tb rd = db.Rem_tb.Where(temp => temp.Rem_id == id).FirstOrDefault();
            db.Rem_tb.Remove(rd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       [HttpPost]
        public ActionResult Edit(Rem_tb rtb)
        {
            Schrdule_dbEntities1 db = new Schrdule_dbEntities1();
            Rem_tb ExRtb=db.Rem_tb.Where(temp => temp.Rem_id == rtb.Rem_id).FirstOrDefault();
            ExRtb.Rem_Desc = rtb.Rem_Desc;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Schrdule_dbEntities1 db = new Schrdule_dbEntities1();
            Rem_tb ExRtb = db.Rem_tb.Where(temp => temp.Rem_id == id).FirstOrDefault();
            return View(ExRtb); 
        }
      
        [HttpPost]
        public ActionResult Create(Rem_tb rt)
        {
            Schrdule_dbEntities1 db = new Schrdule_dbEntities1();
            db.Rem_tb.Add(rt);    
            db.SaveChanges();
            return View();
        }
    }
}