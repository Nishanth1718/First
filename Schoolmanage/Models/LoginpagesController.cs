using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Schoolmanage.Models
{
    public class LoginpagesController : Controller
    {
        private EA_Testing_1Entities4 db = new EA_Testing_1Entities4();

        // GET: Loginpages
        public async Task<ActionResult> Index()
        {
            return View(await db.Loginpages.ToListAsync());
        }

        // GET: Loginpages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loginpage loginpage = await db.Loginpages.FindAsync(id);
            if (loginpage == null)
            {
                return HttpNotFound();
            }
            return View(loginpage);
        }

        // GET: Loginpages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loginpages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserID,Username,FirstName,LastName,Password,PhoneNo,Status")] Loginpage loginpage)
        {
            if (ModelState.IsValid)
            {
                db.Loginpages.Add(loginpage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loginpage);
        }

        // GET: Loginpages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loginpage loginpage = await db.Loginpages.FindAsync(id);
            if (loginpage == null)
            {
                return HttpNotFound();
            }
            return View(loginpage);
        }

        // POST: Loginpages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserID,Username,FirstName,LastName,Password,PhoneNo,Status")] Loginpage loginpage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginpage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loginpage);
        }

        // GET: Loginpages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loginpage loginpage = await db.Loginpages.FindAsync(id);
            if (loginpage == null)
            {
                return HttpNotFound();
            }
            return View(loginpage);
        }

        // POST: Loginpages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Loginpage loginpage = await db.Loginpages.FindAsync(id);
            db.Loginpages.Remove(loginpage);
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
