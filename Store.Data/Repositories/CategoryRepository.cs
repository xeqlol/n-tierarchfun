﻿using Store.Data.Infrastructure;
using Store.Model;
using System;
using System.Linq;

namespace Store.Data.Repositories
{
    class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            return this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();
        }

        public override void Update(Category entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}
