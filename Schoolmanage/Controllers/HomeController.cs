using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Schoolmanage.Models;

namespace Schoolmanage.Controllers
{
  
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Loginpage login)
        {
            if (ModelState.IsValid)
            {
                using(EA_Testing_1Entities4 db = new EA_Testing_1Entities4())
                {
                    var obj = db.Loginpages.Where(a => a.Username.Equals(login.Username) && a.Password.Equals(login.Password)).FirstOrDefault();
                    if(obj != null)
                    {
                        Session["UserName"] = obj.Username.ToString();
                        Session["Password"] = obj.Password.ToString();
                        return RedirectToAction("Userpage");
                    }
                }
            }
            return View(login);
        }
        public ActionResult Userpage()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login");
        }

    }
}