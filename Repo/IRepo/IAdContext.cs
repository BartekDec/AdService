using Repo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using Repo.IRepo;
using System.Data.Entity.Infrastructure;

namespace Repo.IRepo
{
    public interface IAdContext
    {
       DbSet<Category> Category { get; set; }
       DbSet<Advertisement> Advertisement { get; set; }
       DbSet<User> User { get; set; }
       DbSet<AdCategory> AdCategory { get; set; }
        int SaveChanges();
        Database Database { get; }
        DbEntityEntry Entry(object entity);
    }
}