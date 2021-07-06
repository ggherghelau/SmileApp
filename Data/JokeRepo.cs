using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Smile.Models;

namespace Smile.Data
{
    public class JokeRepo : IJokeRepo
    {
        private readonly SmileContext _context;

        public JokeRepo(SmileContext context)
        {
            _context = context;
        }

        public void CreateJoke(Joke jk)
        {
            if(jk == null)
            {
                throw new ArgumentNullException(nameof(jk));
            }
            _context.Jokes.Add(jk);
        }

        public async Task<IEnumerable<Joke>> GetAllJokes()
        {
            return await _context.Jokes.ToListAsync();
        }

        public async Task<Joke> GetJokeById(int id)
        {
            return await _context.Jokes.FirstOrDefaultAsync(jk => jk.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateJoke(Joke jk)
        {
            //no code needed
        }
    }
}