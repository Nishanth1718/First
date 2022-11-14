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
    public class TeacherInfosController : Controller
    {
        private EA_Testing_1Entities3 db = new EA_Testing_1Entities3();

        // GET: TeacherInfos
        public async Task<ActionResult> Index()
        {
            return View(await db.TeacherInfoes.ToListAsync());
        }

        // GET: TeacherInfos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherInfo teacherInfo = await db.TeacherInfoes.FindAsync(id);
            if (teacherInfo == null)
            {
                return HttpNotFound();
            }
            return View(teacherInfo);
        }

        // GET: TeacherInfos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherInfos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Qulification,Subject")] TeacherInfo teacherInfo)
        {
            if (ModelState.IsValid)
            {
                db.TeacherInfoes.Add(teacherInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(teacherInfo);
        }

        // GET: TeacherInfos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherInfo teacherInfo = await db.TeacherInfoes.FindAsync(id);
            if (teacherInfo == null)
            {
                return HttpNotFound();
            }
            return View(teacherInfo);
        }

        // POST: TeacherInfos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Qulification,Subject")] TeacherInfo teacherInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(teacherInfo);
        }

        // GET: TeacherInfos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherInfo teacherInfo = await db.TeacherInfoes.FindAsync(id);
            if (teacherInfo == null)
            {
                return HttpNotFound();
            }
            return View(teacherInfo);
        }

        // POST: TeacherInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TeacherInfo teacherInfo = await db.TeacherInfoes.FindAsync(id);
            db.TeacherInfoes.Remove(teacherInfo);
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
