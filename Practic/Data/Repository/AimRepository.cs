using Microsoft.EntityFrameworkCore;
using Practic.Data.Interfaces;
using Practic.Data.Models;

namespace Practic.Data.Repository
{
    public class AimRepository: IAllAims
    {
        private readonly AppDBContent appDBContent;
        public AimRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Aim> Aims => appDBContent.Aim.Include(c => c.category);
        public IEnumerable<Aim> GetAvaliableAims => appDBContent.Aim.Where(aval => aval.Avaliable).Include(cat => cat.category);

        public IEnumerable<Aim> GetUnavaliableAims => appDBContent.Aim.Where(aval => aval.Avaliable == false).Include(cat => cat.category);
        public Aim getObjectAim(int taskId) => appDBContent.Aim.FirstOrDefault(obj => obj.Id == taskId);
    }
}
