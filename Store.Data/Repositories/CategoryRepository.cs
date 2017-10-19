using Store.Data.Infrastructure;
using Store.Model;

namespace Store.Data.Repositories
{
    class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
    public interface ICategoryRepository : IRepository<Category> { }
}
