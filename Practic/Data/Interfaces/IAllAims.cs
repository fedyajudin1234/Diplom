using Practic.Data.Models;

namespace Practic.Data.Interfaces
{
    public interface IAllAims
    {
        IEnumerable<Aim> Aims { get; }
        IEnumerable<Aim> GetAvaliableAims { get; }
        IEnumerable<Aim> GetUnavaliableAims { get; }
        Aim getObjectAim(int taskId);
    }
}
