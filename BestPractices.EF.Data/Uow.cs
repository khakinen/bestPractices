using System.Threading.Tasks;
using BestPractices.EF.Data.Repositories;

namespace BestPractices.EF.Data
{
    public class Uow : IUow
    {
        private readonly AppDbContext _appDbContext;
        private IStudentRepository _studentRepository;
        private ITeacherRepository _teacherRepository;

        public Uow(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_appDbContext);
                }

                return _studentRepository;
            }
        }

        public ITeacherRepository TeacherRepository
        {
            get
            {
                if (_teacherRepository == null)
                {
                    _teacherRepository = new TeacherRepository(_appDbContext);
                }

                return _teacherRepository;
            }
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}