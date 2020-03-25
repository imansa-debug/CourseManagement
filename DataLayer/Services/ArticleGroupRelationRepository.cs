using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;
namespace DataLayer.Services
{
    public class ArticleGroupRelationRepository : IArticleGroupRelationRepository
    { private CourseManagementEntities db;
        public ArticleGroupRelationRepository(CourseManagementEntities _context)
        {
            db = _context;
        }
       

        public async Task<List<ArticleGroupRelation>> GetAll()
        {
            
           return await Task.Run(() => db.ArticleGroupRelation.ToList());
        }
    }
}
