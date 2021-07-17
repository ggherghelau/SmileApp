using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smile.Models;

namespace Smile.Data
{
    public class SqlCheerRepo : ICheerRepo
    {
        private readonly SmileContext _context;

        public SqlCheerRepo(SmileContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cheer>> GetAllCheers()
        {
            return await _context.Cheers.ToListAsync();
        }

       
        public async Task<Cheer> GetCheerById(int id)
        {
            return await _context.Cheers.FirstOrDefaultAsync(ch => ch.Id == id);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}