using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smile.Models;

namespace Smile.Data
{
    public class SqlPraiseRepo : IPraiseRepo
    {
        private readonly SmileContext _context;

        public SqlPraiseRepo(SmileContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Praise>> GetAllPraises()
        {
            return await _context.Praises.ToListAsync();
        }

       
        public async Task<Praise> GetPraiseById(int id)
        {
            return await _context.Praises.FirstOrDefaultAsync(ch => ch.Id == id);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}