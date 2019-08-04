using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolsAdmin.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolsAdmin.API.Controllers
{
    [Route("api/classroom")]
    public class ClassroomController : Controller
    {
        private IRepositoryWrapper _repository;

        public ClassroomController(IRepositoryWrapper repository)
        {            
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllClassrooms()
        {
            try
            {
                var classrooms = _repository.Classroom.GetAllClassrooms();
                return Ok(classrooms);
                //repository classes inherit from the abstract RepositoryBase<T> class and also from 
                //its own interface which then inherits from the IRepositoryBase<T> 
                //interface. With this hierarchy in place, by typing_repository.Classroom 
                //you are able to call the custom method from the ClassroomRepository class
                //and also all of the methods from the abstract RepositoryBase <T> class.
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Internal server error - " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClassroomById(Guid id)
        {
            try
            {
                var classroom = _repository.Classroom.GetClassroomById(id);

                if (classroom.Id.Equals(Guid.Empty)) //or if(classroom.IsEmptyObject()) 
                {                    
                    return NotFound();
                }
                else
                {                    
                    return Ok(classroom);
                }
            }
            catch (Exception ex)
            {                
                return StatusCode(500, "Internal server error - " + ex.Message);
            }
        }
    }
}
