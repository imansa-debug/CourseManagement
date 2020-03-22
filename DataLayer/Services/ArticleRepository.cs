using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;
namespace DataLayer.Services
{ 
    public class ArticleRepository:IArticleRepository
    {
        private CourseManagementEntities db;
        public ArticleRepository(CourseManagementEntities _context)
        {
            db = _context;
        }
        public List<Article> GetAll()
        {
            return db.Article.ToList();
        }


        public Article GetById(int id)
        {
            return db.Article.Find(id);
        }

      
    }
}
