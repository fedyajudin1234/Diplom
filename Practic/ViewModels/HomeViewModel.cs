using Practic.Data.Models;

namespace Practic.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Aim> avaliableAims { get; set; }
        public IEnumerable<Aim> unavaliableAims { get; set; }
    }
}
