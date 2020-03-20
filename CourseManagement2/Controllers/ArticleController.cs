using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
namespace CourseManagement2.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            CourseManagementEntities dbcontext = new CourseManagementEntities();
            List<Article> articles = dbcontext.Article.ToList();
            ViewBag.ArticleGroup = dbcontext.ArticleGroupRelation.ToList();
            
            return View(articles);
        }

        public ActionResult ArticlePage()
        {
            return View();
        }
    }
}