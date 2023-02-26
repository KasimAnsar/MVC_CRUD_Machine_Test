using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace MVC_CRUD_Machine_Test.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Products> products { get; set; }
    }
}