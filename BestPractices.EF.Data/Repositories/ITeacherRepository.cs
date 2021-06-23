using System.Collections.Generic;
using System.Threading.Tasks;
using BestPractices.EF.Data.Domain;

namespace BestPractices.EF.Data.Repositories
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        Task<IEnumerable<Teacher>> GetSmartTeachers();
    }
}