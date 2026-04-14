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
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [HttpGet("{name}", Name ="GetCourseByName")]
    public IActionResult GetCourseByName(string name)
    {
        try
        {
            Course c = _courseServices.GetCourseByName(name);
            if (c != null) return Ok(c);
            else return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    

    [HttpPost]
    public IActionResult AddCourse(Course c)
    {
        try
        {
            Course returnedCourse = _courseServices.AddCourse(c);
            if (c != null) return CreatedAtRoute("GetCourseByName", new { name = returnedCourse.Name }, returnedCourse);
            else return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }



}
