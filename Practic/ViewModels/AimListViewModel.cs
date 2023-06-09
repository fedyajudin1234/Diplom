using Practic.Data.Models;

namespace Practic.ViewModels
{
    public class AimListViewModel
    {
        public IEnumerable<Aim> getAllAims { get; set; }
        public string currentCategory { get; set; }
    }
}
