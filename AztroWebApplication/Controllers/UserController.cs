using AztroWebApplication.Models;
using AztroWebApplication.Services;
using AztroWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace AztroWebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]


public class UserController : ControllerBase
{

    private readonly UserService userService;

    public UserController(ApplicationDbContext context)
    {
        userService = new UserService(context);
    }

    //New endpoint to get all users
    [HttpGet("all")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await userService.GetAllUsers();
        return Ok(users);
    }


    //New endpoint to get a user by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await userService.GetUserById(id);

        if(user == null)
        {
            return NotFound(new ErrorResponse { Message = "User not found" , StatusCode = 404});
        }

        //Return the user object as a JSON response
        return Ok(user);
    }

    //New endpoint to create a user
    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        var createdUser = await userService.CreateUser(user);
        if (createdUser == null)
        {
            return BadRequest(new ErrorResponse { Message = "User must be between 18 and 80 years old", StatusCode = 400 });
        }
        return Created(nameof(GetUserById), createdUser);
    }

    //New endpoint to update a user
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        var updatedUser = await userService.UpdateUserById(id, user);

        if (updatedUser == null)
        {
            return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404 });
        }

        return Ok(updatedUser);
    }

    //New endpoint to delete a user
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var userRemoved = await userService.DeleteUserById(id);
        if (userRemoved == null)
        return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404 });
        
        return Ok(new { Message = "User deleted", User = userRemoved });
    }

}