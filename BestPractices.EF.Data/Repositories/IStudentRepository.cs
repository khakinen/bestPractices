using System.Collections.Generic;
using System.Threading.Tasks;
using BestPractices.EF.Data.Domain;

namespace BestPractices.EF.Data.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllSpecialStudents();
    }
}