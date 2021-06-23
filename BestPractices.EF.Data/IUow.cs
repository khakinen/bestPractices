using System.Threading.Tasks;
using BestPractices.EF.Data.Repositories;

namespace BestPractices.EF.Data
{
    public interface IUow
    {
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        Task Save();
    }
}