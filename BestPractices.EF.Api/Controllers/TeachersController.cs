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
    public class TeachersController : ControllerBase
    {
        private readonly IUow _uow;
        private readonly ILogger<TeachersController> _logger;

        public TeachersController(ILogger<TeachersController> logger,IUow uow)
        {
            _logger = logger;
            _uow = uow;
        }


        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await _uow.TeacherRepository.GetAll();
        }

        [HttpGet("smarts")]
        public async Task<IEnumerable<Teacher>> GetSmarts()
        {
            return await _uow.TeacherRepository.GetSmartTeachers();
        }
    }
}
