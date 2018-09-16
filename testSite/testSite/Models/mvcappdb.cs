using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace testSite.Models
{
    public class mvcappdb:DbContext
    {
        public DbSet<myContact> myContacts { get; set; }
    }
}