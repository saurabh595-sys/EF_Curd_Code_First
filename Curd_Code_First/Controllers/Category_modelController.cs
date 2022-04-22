using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Curd_Code_First.Models;

namespace Curd_Code_First.Controllers
{
    public class Category_modelController : Controller
    {
        private Contex db = new Contex();

        // GET: Category_model
        public async Task<ActionResult> Index()
        {
            return View(await db.Category.ToListAsync());
        }

        // GET: Category_model/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_model category_model = await db.Category.FindAsync(id);
            if (category_model == null)
            {
                return HttpNotFound();
            }
            return View(category_model);
        }

        // GET: Category_model/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
      
        public async Task<ActionResult> Create([Bind(Include = "CategoryId,CategoryName")] Category_model category_model)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category_model);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category_model);
        }

        // GET: Category_model/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_model category_model = await db.Category.FindAsync(id);
            if (category_model == null)
            {
                return HttpNotFound();
            }
            return View(category_model);
        }

        // POST: Category_model/Edit/5
        
        [HttpPost]
        
        public async Task<ActionResult> Edit([Bind(Include = "CategoryId,CategoryName")] Category_model category_model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_model).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category_model);
        }

        // GET: Category_model/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_model category_model = await db.Category.FindAsync(id);
            if (category_model == null)
            {
                return HttpNotFound();
            }
            return View(category_model);
        }

        // POST: Category_model/Delete/5
        [HttpPost, ActionName("Delete")]
        
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category_model category_model = await db.Category.FindAsync(id);
            db.Category.Remove(category_model);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
