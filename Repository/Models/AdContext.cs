using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repo.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
   

    public class AdContext : IdentityDbContext
    {
        public AdContext()
            : base("DefaultConnection")
        {
        }

        public static AdContext Create()
        {
            return new AdContext();
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Advertisement> Advertisement { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AdCategory> AdCategory { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Turn off auto plural for table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Turn off CascadeDelete
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //Fluent Api for relations between tables
            modelBuilder.Entity<Advertisement>().HasRequired(x => x.User).WithMany(x => x.Advertisement)
                .HasForeignKey(x => x.UserID).WillCascadeOnDelete(true);
        }

    }
}