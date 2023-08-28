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
    public async Task<ActionResult<Student>> GetUser(Guid id)
    {
        var user = await studentRepository.GetById(id);
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<Student>> CreateUser(UserDto user)
    {
        await studentRepository.Add(user);
        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEmail(Guid id, string email)
    {
        await studentRepository.UpdateEmail(id, email);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        await studentRepository.Delete(Guid.Parse(id));
        return NoContent();
    }
}