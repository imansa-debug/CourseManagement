using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {

            List<Article> articles =await dbcontext.ArticleRepository.GetAll();
            ViewBag.ArticleGroup = await dbcontext.ArticleGroupRelationRepository.GetAll();
            return View(articles);
        }

        public async Task<ActionResult> ArticlePage(int id)
        {
            Article article =await dbcontext.ArticleRepository.GetById(id);
            ViewBag.article = article;
            return View(article);
        }
    }
}