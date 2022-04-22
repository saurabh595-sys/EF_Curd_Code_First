using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Curd_Code_First.Models
{
    public class Contex : DbContext 
    {
        public DbSet<Product_Model> Product { get; set; }
        public DbSet<Category_model> Category { get; set; }
    }
}