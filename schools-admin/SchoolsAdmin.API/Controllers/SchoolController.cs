using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolsAdmin.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolsAdmin.API.Controllers
{
    [Route("api/school")]
    public class SchoolController : Controller
    {
        private IRepositoryWrapper _repository;

        public SchoolController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllSchools()
        {
            try
            {
                var schools = _repository.School.GetAllSchools();
                return Ok(schools);
                //repository classes inherit from the abstract RepositoryBase<T> class and also from 
                //its own interface which then inherits from the IRepositoryBase<T> 
                //interface. With this hierarchy in place, by typing_repository.Classroom 
                //you are able to call the custom method from the SchoolRepository class
                //and also all of the methods from the abstract RepositoryBase <T> class.
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error - " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSchoolById(Guid id)
        {
            try
            {
                var school = _repository.School.GetSchoolById(id);

                if (school.Id.Equals(Guid.Empty)) //or if(classroom.IsEmptyObject()) 
                {
                    return NotFound();
                }
                else
                {
                    return Ok(school);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error - " + ex.Message);
            }
        }
    }
}
