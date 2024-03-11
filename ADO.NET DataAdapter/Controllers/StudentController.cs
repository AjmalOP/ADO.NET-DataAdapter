using ADO.NET_DataAdapter.Model;
using ADO.NET_DataAdapter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO.NET_DataAdapter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }
        [HttpPost]
        public IActionResult AddNew(Student student)
        {
            return Ok(_studentService.AddStudent(student));
        }
    }
}
