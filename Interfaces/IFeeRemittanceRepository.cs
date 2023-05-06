using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Interfaces
{
   public interface IFeeRemittanceRepository
    {
        Task<FeeRemittance> CreateFeeRemittance(FeeRemittance obj);
        Task<List<FeeRemittance>> FeeRemittanceList();
    }
}
