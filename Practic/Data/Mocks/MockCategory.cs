using Practic.Data.Interfaces;
using Practic.Data.Models;

namespace Practic.Data.Mocks
{
    public class MockCategory: IAimCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ CategoryName = "Первая часть", Description = "Ознакомление с языкос программирования C#"},
                    new Category{ CategoryName = "Вторая часть", Description = "Изучение классов в языке C#"}
                };
            }
        }
    }
}
