using College.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College.Interfaces
{
    public interface IDegreeRepository
    {
        Task<List<DegreeModel>> DegreeList();
        Task<DegreeModel> SingleDegree(int degreeid);
        Task<DegreeModel> CreateDegree(DegreeModel singledegree);
        Task<DegreeModel> UpdateDegree(DegreeModel singledegree);
        Task<int> DeleteDegree(int degreeid);
    }
}
