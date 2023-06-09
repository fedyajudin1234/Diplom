using Microsoft.EntityFrameworkCore;

namespace Practic.Data.Models
{
    public class AimMaker
    {
        private readonly AppDBContent appDBContent;
        public AimMaker(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string AimItemId { get; set; }
        public List<AimItem> ListAimItems { get; set; }
        public static AimMaker GetAimMaker(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<AppDBContent>();
            string aimMakerId = session.GetString("AimMakerId") ?? Guid.NewGuid().ToString();
            session.SetString("AimMakerId",aimMakerId);
            return new AimMaker(context)
            {
                AimItemId = aimMakerId
            };
        }
        public void StartAim(Aim aim)
        {
            this.appDBContent.AimItems.Add(new AimItem
            {
                aimItemId = AimItemId,
                aim = aim
            });
            appDBContent.SaveChanges();
        }
        public List<AimItem> getAimItems()
        {
            return appDBContent.AimItems.Where(elem => elem.aimItemId == AimItemId).Include(obj => obj.aim).ToList();
        }
    }
}
