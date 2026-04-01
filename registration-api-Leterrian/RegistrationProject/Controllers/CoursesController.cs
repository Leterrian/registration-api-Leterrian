using Microsoft.AspNetCore.Mvc;
using CourseRegistration.Models;
using CourseRegistration.Services;

namespace CourseRegistration.Controllers;

[ApiController]
[Route("[controller]")]

public class CoursesController : ControllerBase
{

    private ICourseServices _courseServices;
    public CoursesController(ICourseServices courseServices)
    {

        _courseServices = courseServices;
    }

    [HttpGet]
    public IActionResult GetAllCourses()
    {
        try
        {
            IEnumerable<Course> list = _courseServices.GetAllCourses();
            if (list != null) return Ok(list);
            else return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal server error");
        }
    }


}
