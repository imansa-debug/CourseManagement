using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class ArticleGroupRepository : IArticleGroupRepository
    {
        private CourseManagementEntities db;
        public ArticleGroupRepository(CourseManagementEntities _context)
        {
            db = _context;
        }
        public async Task<List<ArticleGroups>> GetAll()
        {
            return await Task.Run(() => db.ArticleGroups.ToList());
        }
    }
}
