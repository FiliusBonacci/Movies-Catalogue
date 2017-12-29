using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
   
    public class Review
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int UserID { get; set; }
        public int Grade { get; set; }

        public virtual Movie Movie { get; set; }
//        public virtual User User { get; set; }

    }
}