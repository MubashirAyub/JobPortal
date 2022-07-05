using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortalProject;

namespace JobPortalProject.Controllers
{
   [Session]
    public class JobPostsController : Controller
    {
        private JobPortalEntities db = new JobPortalEntities();

        // GET: JobPosts
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {

                return View(db.JobPosts.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Show(string id)
        {
            Session["jobtitle"] = id;
            return RedirectToAction("Create", "JobApplicants");
        }

        // GET: JobPosts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // GET: JobPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_JobPost,ApplyEmail,JobTitle,Location,JobType,JobCategory,Job_Description,Company_Name,Salary,MinimumExperience,MinimumQualification,Required_Skills,Website_Company,Facebook__Company,Google_USERNAME,LINKEDIN_USERNAME,TWITTER_USERNAME,Job_ExpiryDate,Job_DatePosted,Available")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.JobPosts.Add(jobPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobPost);
        }

        // GET: JobPosts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_JobPost,ApplyEmail,JobTitle,Location,JobType,JobCategory,Job_Description,Company_Name,Salary,MinimumExperience,MinimumQualification,Required_Skills,Website_Company,Facebook__Company,Google_USERNAME,LINKEDIN_USERNAME,TWITTER_USERNAME,Job_ExpiryDate,Job_DatePosted,Available")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobPost);
        }

        // GET: JobPosts/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
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
    }
}
