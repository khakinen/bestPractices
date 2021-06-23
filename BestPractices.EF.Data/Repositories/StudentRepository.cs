using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestPractices.EF.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.EF.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<IEnumerable<Student>> GetAllSpecialStudents()
        {
            return await base._dbSet.Where(s => s.StudentRank == 2).ToListAsync();
        }
    }
}