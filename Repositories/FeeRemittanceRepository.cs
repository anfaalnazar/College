using College.Interfaces;
using College.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace College.Repositories
{
    public class FeeRemittanceRepository : IFeeRemittanceRepository
    {
        private readonly CollegeContext _appDbContext;
        private readonly IConfiguration _config;

        public FeeRemittanceRepository(CollegeContext appDbContext,IConfiguration config)
        {
            _appDbContext = appDbContext;
            _config = config;
        }
        public async Task<FeeRemittance> CreateFeeRemittance(FeeRemittance obj)
        {
            await Task.Run(() =>
            {
                using (var context = new CollegeContext(_config))
                {
                    //var entity = new MyEntity { Name = "New Entity" };
                    context.feeremittance.Add(obj);
                    context.SaveChanges();
                }
            });
            return null;
        }

        public Task<List<FeeRemittance>> FeeRemittanceList()
        {
            return _appDbContext.feeremittance.ToListAsync();
        }
    }
}
