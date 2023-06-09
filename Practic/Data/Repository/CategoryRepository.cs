using Practic.Data.Interfaces;
using Practic.Data.Models;

namespace Practic.Data.Repository
{
    public class CategoryRepository: IAimCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
