using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        Article GetById(int id);

    }
}
