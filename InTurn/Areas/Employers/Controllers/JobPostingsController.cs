using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InTurn_Model;
using Microsoft.AspNet.Identity;

namespace InTurn.Areas.Employers.Controllers
{
    [Authorize(Roles = "Admin,Employer")]
    public class JobPostingsController : Controller
    {
        private InTurnEntities db = new InTurnEntities();

        // GET: Employers/JobPostings
        public ActionResult Index()
        {
            var jobPostings = db.JobPostings.Include(j => j.Employer);
            return View(jobPostings.ToList());
        }

        // GET: Employers/JobPostings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            return View(jobPosting);
        }

        // GET: Employers/JobPostings/Create
        public ActionResult Create()
        {
            var user = User.Identity.GetUserId();
            var aspUser = db.AspNetUsers.Find(user);
            var employer=db.Employers.FirstOrDefault(e => e.Email == aspUser.Email);
            ViewBag.Employer = employer;
            return View();
        }

        // POST: Employers/JobPostings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobPostingID,EmployerID,Position,Desc,Wage,Location,JobType,TimeType,Days,Hours")] JobPosting jobPosting)
        {
            if (ModelState.IsValid)
            {
                db.JobPostings.Add(jobPosting);
                db.SaveChanges();
                return RedirectToAction("Index","EmployerHome");
            }

          
            return View(jobPosting);
        }

        // GET: Employers/JobPostings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
           
            return View(jobPosting);
        }

        // POST: Employers/JobPostings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobPostingID,EmployerID,Position,Desc,Wage,Location,JobType,TimeType,Days,Hours")] JobPosting jobPosting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPosting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","EmployerHome");
            }
           
            return View(jobPosting);
        }

        // GET: Employers/JobPostings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosting jobPosting = db.JobPostings.Find(id);
            if (jobPosting == null)
            {
                return HttpNotFound();
            }
            return View(jobPosting);
        }

        // POST: Employers/JobPostings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPosting jobPosting = db.JobPostings.Find(id);
            db.JobPostings.Remove(jobPosting);
            db.SaveChanges();
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
        public ActionResult AppCount(int count)
        {
            foreach (var app in db.JobPostings.ToList())
            {
                int id = app.JobPostingID;
                count = db.Applications.Where(a => a.JobPostingID == id).Count();
            }
            ViewBag.AppCount = count;
            return View(count);


        }

    }
}
