using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using Repo.IRepo;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace Repo
{
    public class AdvertisementRepo : Controller, IAdvertisementRepo
    {
       
        private readonly IAdContext _db = new AdContext();

        public AdvertisementRepo(IAdContext db)
        {
           _db = db;
        }
        public IQueryable<Advertisement> GetAdvertisement()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Advertisement.AsNoTracking();
        }
        public Advertisement GetAdvertisementById(int id)
        {
            Advertisement ad = _db.Advertisement.Find(id);
            return ad;
        }
        public void DeleteAd(int id)
        {
            Advertisement ad = _db.Advertisement.Find(id);
            _db.Advertisement.Remove(ad);
            
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void CreateAd(Advertisement ad)
        {
            _db.Advertisement.Add(ad);

        }

        public void Update(Advertisement ad)
        {
            _db.Entry(ad).State = EntityState.Modified;

        }
    }
}
