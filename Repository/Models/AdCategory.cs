using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repo.Models
{
    public class AdCategory
    {
        public AdCategory()
        {
               
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AdId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Advertisement Advertisement { get; set; }
    }
}