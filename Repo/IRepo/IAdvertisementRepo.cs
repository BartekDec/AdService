using Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.IRepo
{
    public interface IAdvertisementRepo
    {
        IQueryable<Advertisement> GetAdvertisement();
        Advertisement GetAdvertisementById(int id);
        void DeleteAd(int id);
        void SaveChanges();
        void CreateAd(Advertisement ad);
        void Update(Advertisement ad);
        
    }
}