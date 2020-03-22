using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Context;
namespace CourseManagement2.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        UnitOfWork dbcontext = new UnitOfWork();
        public ActionResult Index()
        {

            List<Article> articles = dbcontext.ArticleRepository.GetAll();
            ViewBag.ArticleGroup = dbcontext.ArticleGroupRelationRepository.GetAll();

            return View(articles);
        }

        public ActionResult ArticlePage(int id)
        {
            Article article = dbcontext.ArticleRepository.GetById(id);
            ViewBag.article = article;
            return View(article);
        }
    }
}