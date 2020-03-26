using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Utility;
using System.IO;

namespace CourseManagement2.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private CourseManagementEntities db = new CourseManagementEntities();

        // GET: Admin/Articles
        public async Task<ActionResult> Index()
        {
            return View(await db.Article.ToListAsync());
        }

        // GET: Admin/Articles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.Article.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/Articles/Create
        public ActionResult Create()
        {
            List<SelectListItem> groupList = new List<SelectListItem>();
            foreach (var group in db.ArticleGroups.ToList())
            {
                groupList.Add(new SelectListItem { Text = group.GroupName, Value = group.ID.ToString() });
            }
            ViewBag.articlegroup = groupList;
            return View();
        }

        // POST: Admin/Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( Article article, HttpPostedFileBase imageProduct,HttpPostedFileBase videoProduct)
        {
            if (ModelState.IsValid)
            {
                article.Image = "images.jpg";
                if (imageProduct != null && imageProduct.IsImage())
                {
                    article.Image = Guid.NewGuid().ToString() + Path.GetExtension(imageProduct.FileName);
                    imageProduct.SaveAs(Server.MapPath("/Images/Articles/" + article.Image));
                    ImageResizer img = new ImageResizer();
                    img.Resize(Server.MapPath("/Images/Articles/" + article.Image),
                        Server.MapPath("/Images/Articles/Thumb/" + article.Image));

                }
               
                if (videoProduct != null)
                {
                    article.Video = Guid.NewGuid().ToString() + Path.GetExtension(videoProduct.FileName);
                    videoProduct.SaveAs(Server.MapPath("/Videos/" + article.Video));
                }



                article.CreateDate = DateTime.Now;
                article.Author = "ایمان صفری";

                db.Article.Add(article);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            List<SelectListItem> groupList = new List<SelectListItem>();
            foreach (var group in db.ArticleGroups.ToList())
            {
                groupList.Add(new SelectListItem { Text = group.GroupName, Value = group.ID.ToString() });
            }
            ViewBag.articlegroup = groupList;
            return View(article);
        }

        // GET: Admin/Articles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.Article.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,Text,Image,Video,Author,CreateDate")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        // GET: Admin/Articles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = await db.Article.FindAsync(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Article article = await db.Article.FindAsync(id);
            db.Article.Remove(article);
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
