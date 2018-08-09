using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repo.Models
{
    public class Category
    {
        public Category()
        {
            this.AdCategory = new HashSet<AdCategory>();

        }
        [Key]
        [Display(Name = "Id Category:")]
        public int Id { get; set; }

        [Display(Name = "Name of Category:")]
        [Required(ErrorMessage = "Fill in Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Parent Id:")]
        [Required(ErrorMessage ="Fill in Id")]
        public int ParentId { get; set; }

        public ICollection<AdCategory> AdCategory { get; set; }


    }
}