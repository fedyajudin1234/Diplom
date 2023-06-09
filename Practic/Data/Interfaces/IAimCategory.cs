using Practic.Data.Models;

namespace Practic.Data.Interfaces
{
    public interface IAimCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
