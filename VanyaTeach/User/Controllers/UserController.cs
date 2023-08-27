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
    public IEnumerable<User.Data.Models.UserDto> GetAll() =>
        userRepository.GetAll();


    [HttpGet("{id:guid}")]
    public ActionResult<UserDto> GetUser(Guid id)
    {
        var user = userRepository.GetById(id);
        return user;
    }

    [HttpPost]
    public ActionResult<UserDto> CreateUser(UserDto userDto)
    {
        userRepository.AddUser(userDto);
        return CreatedAtAction(nameof(GetUser), new {id = userDto.Id}, userDto);
    }

    [HttpPut]
    public IActionResult UpdateUser(UserDto userDto)
    {
        userRepository.Update(userDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(string id)
    {
        userRepository.Delete(Guid.Parse(id));
        return NoContent();
    }
}