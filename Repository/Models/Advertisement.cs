using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repo.Models
{
    public class Advertisement
    {
        public Advertisement()
        {
            this.AdCategory = new HashSet<AdCategory>();
        }

    
        [Display(Name = "Id:")]
        public int Id { get; set; }

        [Display(Name = "Content:")]
        [MaxLength(500)]
        public string Content { get; set; }

        [Display(Name = "Title:")]
        [MaxLength(70)]
        public string Title { get; set; }

        [Display(Name = "Date of adding:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", 
                    ApplyFormatInEditMode = true)]

        public System.DateTime DateOfAdd { get; set; }

        public string UserID { get; set; }

        public virtual ICollection<AdCategory>
            AdCategory
        { get; set; }

        public virtual User User { get; set; }
    }
}