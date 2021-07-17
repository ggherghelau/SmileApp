using System.Collections.Generic;
using System.Threading.Tasks;
using Smile.Models;

namespace Smile.Data
{
    public interface IPraiseRepo
    {
        Task<IEnumerable<Praise>> GetAllPraises();
        Task<Praise> GetPraiseById(int id);
        bool SaveChanges();
    }
}