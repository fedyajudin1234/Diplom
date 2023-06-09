namespace Practic.Data.Models
{
    public class Aim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string shortDescription { get; set; }
        public string TextField { get; set; }
        public string AimTextField { get; set; }
        public string Image { get; set; }
        public bool Avaliable { get; set; }
        public virtual Category category { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser applicationUser { get; set; }
    }
}
