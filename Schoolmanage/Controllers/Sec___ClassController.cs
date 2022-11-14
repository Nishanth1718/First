using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schoolmanage.Models;

namespace Schoolmanage.Controllers
{
    public class Sec___ClassController : Controller
    {
        private EA_Testing_1Entities6 db = new EA_Testing_1Entities6();

        // GET: Sec___Class
        public async Task<ActionResult> Index()
        {
            return View(await db.Sec___Class.ToListAsync());
        }

        // GET: Sec___Class/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sec___Class sec___Class = await db.Sec___Class.FindAsync(id);
            if (sec___Class == null)
            {
                return HttpNotFound();
            }
            return View(sec___Class);
        }

        // GET: Sec___Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sec___Class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Class_Id,Class___sec,Class_stregnth,Class_Teacher")] Sec___Class sec___Class)
        {
            if (ModelState.IsValid)
            {
                db.Sec___Class.Add(sec___Class);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sec___Class);
        }

        // GET: Sec___Class/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sec___Class sec___Class = await db.Sec___Class.FindAsync(id);
            if (sec___Class == null)
            {
                return HttpNotFound();
            }
            return View(sec___Class);
        }

        // POST: Sec___Class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Class_Id,Class___sec,Class_stregnth,Class_Teacher")] Sec___Class sec___Class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sec___Class).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sec___Class);
        }

        // GET: Sec___Class/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sec___Class sec___Class = await db.Sec___Class.FindAsync(id);
            if (sec___Class == null)
            {
                return HttpNotFound();
            }
            return View(sec___Class);
        }

        // POST: Sec___Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sec___Class sec___Class = await db.Sec___Class.FindAsync(id);
            db.Sec___Class.Remove(sec___Class);
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
