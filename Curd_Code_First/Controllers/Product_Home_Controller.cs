using Curd_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Curd_Code_First.Controllers
{
    public class Product_Home_Controller : Controller
    {
        Contex db = new Contex();

        // GET: Product_Home_
        public async Task<ActionResult> Index(int pg = 1)
        {

            var AllProducts = await db.Product.ToListAsync();

            const int pageSize = 10;
            var param1 = new SqlParameter();
            param1.ParameterName = "@PageNumber";
            param1.SqlDbType = SqlDbType.Int;
            param1.SqlValue = pg;

            var param2 = new SqlParameter();
            param2.ParameterName = "@PageSize";
            param2.SqlDbType = SqlDbType.NVarChar;
            param2.SqlValue = pageSize;

            var result = await db.Product.SqlQuery("spGetRowsPerPage @PageNumber,@PageSize", param1, param2).ToListAsync();


            
            if (pg < 1)
            {
                pg = 1;
            }

            int rescount = AllProducts.Count();
            //int rescount = result.Count();
            
            var pager = new Pager(rescount, pg, pageSize);
            //int recSkip = (pg - 1) * pageSize;
            //var data = AllProducts.Skip(recSkip).Take(pager.PageSize).ToList();
            var data = result;
            this.ViewBag.pager = pager;
            return View(data);
        }

        public ActionResult  Create()
        {
            ViewBag.CategoryId = new SelectList( db.Category, "CategoryId", "CategoryName");
          
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Product_Model p)
        {
            if(ModelState.IsValid == true)
            {
                db.Product.Add(p);
                int a= await db.SaveChangesAsync();
                if (a > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //ViewBag.createMessage=("<script>alert('Data Not Inserted ...')</script>");
                }
            }
            
            return View();
        }
            
        public ActionResult Edit(int id)
        {
            var Edit_row = db.Product.Where(Model => Model.ProductId == id).FirstOrDefault();
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName");

            return View(Edit_row);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product_Model p)
        {
            db.Entry(p).State = EntityState.Modified;
           int a= await db.SaveChangesAsync();
            if (a>0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var Delete_row = db.Product.Where(Model => Model.ProductId == id).FirstOrDefault();
            return View(Delete_row);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Product_Model p , int id)
        {
                var Delete_row = db.Product.Where(Model => Model.ProductId == id).FirstOrDefault();
                db.Product.Remove(Delete_row);
             int a= await db.SaveChangesAsync();
            if (a > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}