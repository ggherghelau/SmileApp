using System.Collections.Generic;
using System.Threading.Tasks;
using Smile.Models;

namespace Smile.Data
{
    public interface IJokeRepo
    {
        Task<IEnumerable<Joke>> GetAllJokes();
        Task<Joke> GetJokeById(int id);
    }
}