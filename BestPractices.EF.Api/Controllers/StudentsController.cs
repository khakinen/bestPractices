using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestPractices.EF.Data;
using BestPractices.EF.Data.Domain;
using BestPractices.EF.Data.Repositories;

namespace BestPractices.EF.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
       
        private readonly ILogger<StudentsController> _logger;
        private readonly IUow _uow;

        public StudentsController(IUow uow, ILogger<StudentsController> logger)
        {
            _uow = uow;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _uow.StudentRepository.GetAll();
        }

        [HttpGet("specials")]
        public async Task<IEnumerable<Student>> GetSpecials()
        {
            return await _uow.StudentRepository.GetAllSpecialStudents();
        }

        [HttpPost]
        public async Task AddStudent(Student student)
        { 
            await _uow.StudentRepository.Insert(student);
            await _uow.Save();
        }
    }
}
