using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repo.Models;
using System.Diagnostics;

using Repo;
using Repo.IRepo;
using Microsoft.AspNet.Identity;

namespace AdService.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertisementRepo _repo;

        public AdvertisementController(IAdvertisementRepo repo)
        {
            this._repo = repo;
                
        }
        //AdvertisementRepo repo = new AdvertisementRepo();
      

        // GET: Advertisement
        public ActionResult Index()
        {
           
            var advertisement = _repo.GetAdvertisement();
            return View(advertisement);
        }


        // GET: Advertisement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = _repo.GetAdvertisementById((int)id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }

        //    // GET: Advertisement/Create
        [Authorize]
        public ActionResult Create()
        {
            
            return View();
        }

        //    // POST: Advertisement/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Content,Title")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                advertisement.UserID = User.Identity.GetUserId();
                advertisement.DateOfAdd = DateTime.Now;
                try
                {
                    _repo.CreateAd(advertisement);
                    _repo.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch
                {
                    return View(advertisement);
                }
              
            }

            return View(advertisement);
        }

        //    // GET: Advertisement/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = _repo.GetAdvertisementById((int)id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            else if (advertisement.UserID != User.Identity.GetUserId() && !(User.IsInRole("Admin") || User.IsInRole("Employee")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            
            return View(advertisement);
        }

        //    // POST: Advertisement/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,Title,DateOfAdd,UserID")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(advertisement);
                    _repo.SaveChanges();

                }
                catch
                {
                    ViewBag.error = true;
                    return View(advertisement);

                }


            }
            ViewBag.error = false;
            return View(advertisement);
        }

        //    // GET: Advertisement/Delete/5
        [Authorize]
        public ActionResult Delete(int? id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = _repo.GetAdvertisementById((int)id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            else if (advertisement.UserID != User.Identity.GetUserId() && !(User.IsInRole("Admin")))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (error != null)
                ViewBag.error = true;

            return View(advertisement);
        }

        //    // POST: Advertisement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteAd(id);
            try
            {
                _repo.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, error = true });
            }
          
            return RedirectToAction("Index");
        }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
    }
}
