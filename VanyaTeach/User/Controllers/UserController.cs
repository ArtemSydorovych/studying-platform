using Microsoft.AspNetCore.Mvc;
using VanyaTeach.User.Data.Models;
using VanyaTeach.User.Repositories;

namespace VanyaTeach.User.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ILogger<UserController> logger, IStudentRepository studentRepository) : ControllerBase
{
    private readonly ILogger<UserController> _logger = logger;

    [HttpGet(Name = "GetAllUsers")]
    public IEnumerable<Student> GetAll() =>
        studentRepository.GetAll();


    [HttpGet("{id:guid}")]
    public ActionResult<Student> GetUser(Guid id)
    {
        var user = studentRepository.GetById(id);
        return user;
    }

    [HttpPost]
    public ActionResult<Student> CreateUser(UserDto user)
    {
        studentRepository.Add(user);
        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateUser(Guid id, UserDto user)
    {
        studentRepository.Update(id, user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(string id)
    {
        studentRepository.Delete(Guid.Parse(id));
        return NoContent();
    }
}