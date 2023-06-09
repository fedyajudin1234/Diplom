namespace Practic.Data.Models
{
    public class CompilerDetail
    {
        public int Id { get; set; }
        public int compilerId { get; set; }
        public int AimId { get; set; }
        public virtual Aim aim { get; set; }
        public virtual Compiler compiler { get; set; }
    }
}
