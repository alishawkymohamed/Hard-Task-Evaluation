using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hard_Task_Evaluation.Models;

namespace Hard_Task_Evaluation.Controllers
{
    [Authorize]
    public class Food_SupplementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index(string Id)
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName");
            if (Id == null)
            {
                var food_Supplements = db.Food_Supplements.Include(f => f.User).ToList().OrderBy(x => x.User.FullName);
                return View(food_Supplements.ToList());
            }
            else
            {
                var food_Supplements = db.Users.Include(x => x.Food_Supplements).Where(x => x.Id == Id).SelectMany(x => x.Food_Supplements);
                    //db.Food_Supplements.Include(f => f.User).ToList().OrderBy(x => x.User.FullName);
                return View(food_Supplements.ToList());
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Food_Supplements food_Supplements)
        {
            if (ModelState.IsValid)
            {
                db.Food_Supplements.Add(food_Supplements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", food_Supplements.UserId);
            return View(food_Supplements);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Supplements food_Supplements = db.Food_Supplements.Find(id);
            if (food_Supplements == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FullName", food_Supplements.UserId);
            return View(food_Supplements);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Food_SupplementsType,Name,Time,Item,Quantity,Protien,Fat,Carb,TotalCalories,UserId")] Food_Supplements food_Supplements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_Supplements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", food_Supplements.UserId);
            return View(food_Supplements);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Supplements food_Supplements = db.Food_Supplements.Find(id);
            if (food_Supplements == null)
            {
                return HttpNotFound();
            }
            return View(food_Supplements);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food_Supplements food_Supplements = db.Food_Supplements.Find(id);
            db.Food_Supplements.Remove(food_Supplements);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
