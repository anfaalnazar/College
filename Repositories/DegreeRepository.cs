using College.Interfaces;
using College.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Repositories
{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly CollegeContext _appDbContext;

        public DegreeRepository(CollegeContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<DegreeModel> CreateDegree(DegreeModel singledegree)
        {

            _appDbContext.Add(singledegree);
            _appDbContext.SaveChangesAsync();
            var savedegree = _appDbContext.Degree.SingleOrDefaultAsync(x => x.degreeid == singledegree.degreeid);

            return savedegree;
        }

        public Task<List<DegreeModel>> DegreeList()
        {

            return _appDbContext.Degree.ToListAsync();
            
        }

        public Task<int> DeleteDegree(int degreeid)
        {
            var game = _appDbContext.Degree
                .FirstOrDefaultAsync(m => m.degreeid == degreeid).Result;
            game.IsActive = 0;
            _appDbContext.SaveChangesAsync();
            return Task.FromResult(degreeid);
        }

        public Task<DegreeModel> SingleDegree(int degreeid)
        {
            var game = _appDbContext.Degree
                .FirstOrDefaultAsync(m => m.degreeid == degreeid);
            return game;
        }

        public Task<DegreeModel> UpdateDegree(DegreeModel singledegree)
        {
            _appDbContext.Update(singledegree);
            _appDbContext.SaveChangesAsync();
            var game = _appDbContext.Degree.SingleOrDefaultAsync(x => x.degreeid == singledegree.degreeid);
            return game;
        }
    }
}
