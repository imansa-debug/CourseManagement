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
        

       public async Task<List<Article>> GetAll()
        {
            return await Task.Run(() => db.Article.ToList());
            
        }

       public async Task<Article> GetById(int id)
        {
            return await Task.Run(() => db.Article.FindAsync(id));
        }
    }
}
