using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestPractices.EF.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.EF.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IEnumerable<Teacher>> GetSmartTeachers()
        {
            return await base._dbSet.Where(s => s.TeacherRank == 2).ToListAsync();
        }
    }
}