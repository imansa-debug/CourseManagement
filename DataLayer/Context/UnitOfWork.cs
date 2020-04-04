using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;
using DataLayer.Services;

namespace DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        CourseManagementEntities db = new CourseManagementEntities();
        private IArticleRepository _articleRepository;
        public IArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(db);
                }

                return _articleRepository;
            }
        }

       
        private IArticleGroupRepository _articleGroupRepository;
        public IArticleGroupRepository ArticleGroupRepository
        {
            get
            {
                if (_articleGroupRepository == null)
                {
                    _articleGroupRepository = new ArticleGroupRepository(db);
                }

                return _articleGroupRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
