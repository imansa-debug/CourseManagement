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

        private IArticleGroupRelationRepository _articleGroupRelationRepository;
        public IArticleGroupRelationRepository ArticleGroupRelationRepository
        {
            get
            {
                if (_articleGroupRelationRepository == null)
                {
                    _articleGroupRelationRepository = new ArticleGroupRelationRepository(db);
                }

                return _articleGroupRelationRepository;
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
