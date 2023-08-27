using Microsoft.AspNetCore.Mvc;
using VanyaTeach.User.Data.Models;
using VanyaTeach.User.Repositories;

namespace VanyaTeach.User.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ILogger<UserController> logger, IUserRepository userRepository) : ControllerBase
{
    private readonly ILogger<UserController> _logger = logger;

    [HttpGet(Name = "GetAllUsers")]
    public IEnumerable<User.Data.Models.User> GetAll() =>
        userRepository.GetAll();


    [HttpGet("{id:guid}")]
    public ActionResult<Data.Models.User> GetUser(Guid id)
    {
        var user = userRepository.GetById(id);
        return user;
    }

    [HttpPost]
    public ActionResult<Data.Models.User> CreateUser(UserDto user)
    {
        userRepository.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateUser(Guid id, UserDto user)
    {
        userRepository.Update(id, user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(string id)
    {
        userRepository.Delete(Guid.Parse(id));
        return NoContent();
    }
}