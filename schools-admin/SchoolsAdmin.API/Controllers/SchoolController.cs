using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolsAdmin.Contracts;
using SchoolsAdmin.Domain.Entities.Models;

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

        [HttpGet("{id}", Name = "SchoolById")]
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

        [HttpGet("{id}/classroom")] //Rota: localhost:5000/api/school/{id}/classroom
        public IActionResult GetSchoolWithDetails(Guid id)
        {
            try
            {
                var school = _repository.School.GetSchoolWithDetails(id);

                if (school.Id.Equals(Guid.Empty))
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

        [HttpPost]
        public IActionResult CreateSchool([FromBody]School school)
        {
            try
            {
                if (school == null)
                {                    
                    return BadRequest("School object is null");
                }

                if (!ModelState.IsValid)
                {                    
                    return BadRequest("Invalid model object");
                }

                _repository.School.Create(school);
                _repository.Save();

                //201 created, with id returned
                return CreatedAtRoute("SchoolById", new { id = school.Id }, school);
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Internal server error - " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchool(Guid id, [FromBody]School school)
        {
            try
            {
                if (school == null)
                {                    
                    return BadRequest("School object is null");
                }

                if (!ModelState.IsValid)
                {                    
                    return BadRequest("Invalid model object");
                }

                var dbSchool = _repository.School.GetSchoolById(id);
                if (dbSchool.Id.Equals(Guid.Empty))
                {                    
                    return NotFound();
                }

                _repository.School.UpdateSchool(dbSchool, school);
                _repository.Save();

                //NoContent() = return 204
                return NoContent();
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Internal server error - " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchool(Guid id)
        {
            try
            {
                var school = _repository.School.GetSchoolById(id);
                if (school == null)
                {                    
                    return NotFound();
                }

                if (_repository.Classroom.ClassroomsBySchool(id).Any())
                {                    
                    return BadRequest("Cannot delete school. It has related classroom(s). Delete all classrooms first");
                }

                _repository.School.Delete(school);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error - " + ex.Message);
            }
        }
    }
}
