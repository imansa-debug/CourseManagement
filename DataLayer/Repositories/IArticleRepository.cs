﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAll();
        Task<Article> GetById(int id);

    }
}
