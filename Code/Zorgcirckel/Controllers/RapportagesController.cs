using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zorgcirckel.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Zorgcirckel.Controllers
{
    [Authorize]
    public class RapportagesController : Controller
    {
        private ZorgCirkelEntities db = new ZorgCirkelEntities();

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Rapportages
        public ActionResult Index()
        {
            bool isPatient = true;
            var userId = User.Identity.GetUserId();
            ViewBag.user = db.AspNetUsers.Find(userId);

            if (!User.IsInRole("Patient"))
            {
                isPatient = false;
                List<AspNetUsers> patienten = new List<AspNetUsers>();
                foreach(var verbinding in db.Contacten)
                {
                    if(verbinding.ContactpersoonID == userId)
                    {
                        patienten.Add(verbinding.AspNetUsers);
                    }
                }
                ViewBag.patienten = patienten;  
            }

            ViewBag.isPatient = isPatient;

            var rapportages = db.Rapportages.Include(r => r.AspNetUsers);
            return View(rapportages.ToList());
        }

        // GET: Rapportages/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUsersID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Rapportages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RapportageID,AspNetUsersID,Rapportage,Datum,PatientID")] Rapportages rapportages)
        {
            rapportages.AspNetUsersID = User.Identity.GetUserId();
            rapportages.Datum = DateTime.Now;
            rapportages.PatientID = ViewBag.patientId;

            rapportages.AspNetUsers1 = db.AspNetUsers.Find(rapportages.AspNetUsersID);
            rapportages.AspNetUsers = db.AspNetUsers.Find(rapportages.PatientID);



            if (ModelState.IsValid)
            {
                db.Rapportages.Add(rapportages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUsersID = new SelectList(db.AspNetUsers, "Id", "Email", rapportages.AspNetUsersID);
            return View(rapportages);
        }

        // GET: Rapportages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rapportages rapportages = db.Rapportages.Find(id);

            if (rapportages == null)
            {
                return HttpNotFound();
            }


            if (User.Identity.GetUserId() == rapportages.AspNetUsersID){
                ViewBag.AspNetUsersID = new SelectList(db.AspNetUsers, "Id", "Email", rapportages.AspNetUsersID);
                return View(rapportages);
            }
            return RedirectToAction("Index");
        }

        // POST: Rapportages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RapportageID,AspNetUsersID,Rapportage,Datum,PatientID")] Rapportages rapportages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rapportages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUsersID = new SelectList(db.AspNetUsers, "Id", "Email", rapportages.AspNetUsersID);
            return View(rapportages);
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
