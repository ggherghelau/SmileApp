using System.Collections.Generic;
using System.Threading.Tasks;
using Smile.Models;

namespace Smile.Data
{
    public interface ICheerRepo
    {
        Task<IEnumerable<Cheer>> GetAllCheers();
        Task<Cheer> GetCheerById(int id);
        bool SaveChanges();
    }
}