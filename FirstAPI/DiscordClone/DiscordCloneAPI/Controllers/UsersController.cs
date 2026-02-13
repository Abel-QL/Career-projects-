using Microsoft.AspNetCore.Mvc;
using DiscordClone.Models;

namespace DiscordClone.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase{
    private static readonly List<Users> _users = new List<Users>() {
        new Users {Id = 1, UserName = "User1", Email = "user1@gmail,com", Password = "contraseña segura", CreateDate = DateTime.Now.AddDays(-10), UpdateDate = DateTime.Now.AddDays(-5), IsSuscribe = false},
        new Users {Id = 2, UserName = "User3", Email = "usuario21@gmail,com", Password = "contraseña mas segura aun", CreateDate = DateTime.Now.AddDays(-20), UpdateDate = DateTime.Now.AddDays(-12), IsSuscribe = false},
        new Users {Id = 1, UserName = "Soy3", Email = "usuaro23@gmail,com", Password = "contraseña segura segurisisima", CreateDate = DateTime.Now.AddDays(-100), UpdateDate = DateTime.Now.AddDays(-50), IsSuscribe = true, IsAdmin = true}
    };

    // get para obtner la lista de usuarios
    [HttpGet]
    public IActionResult Get(){
        // devuela
        var response = _users.Select(s => new UsersDto {Id = s.Id, UserName = s.UserName, Password = s.Password, Email = s.Email, IsSuscribe = s.IsSuscribe, IsAdmin = s.IsAdmin, IsActive = s.IsActive, IsBot = s.IsBot}).ToList();
        return Ok(response);
    }

    // obtiene el id 
    [HttpGet("{id}")]
    public IActionResult Get(int id){
        var user = _users.FirstOrDefault(u => u.Id == id);
        if(user == null) {
            return NotFound();
        }

        return Ok(user);
    }

    // crear un post o un usuario, como sea para subirlo al API
    [HttpPost]
    public IActionResult Post([FromBody] UsersDto rquest){
        rquest.Id = _users.Max(u => u.Id) + 1;
        var user = new Users {UserName = rquest.UserName, Password = rquest.Password, Email = rquest.Email, IsSuscribe = rquest.IsSuscribe, IsAdmin = rquest.IsAdmin, IsActive = rquest.IsActive, StateActivity = rquest.StateActivity, CreateDate = DateTime.Now, UpdateDate = DateTime.Now};
        _users.Add(user);
        return CreatedAtAction(nameof(Get), new {id = rquest.Id}, rquest);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UsersDto request){
        var user = _users.FirstOrDefault(u => u.Id == id);
        if(user == null) {
            return NotFound();
        }

        user.UserName = request.UserName;
        user.UpdateDate = DateTime.Now;
        user.IsSuscribe = request.IsSuscribe;
        user.StateActivity = request.StateActivity;
        user.IsAdmin = request.IsAdmin;
        user.Password = request.Password;
        return NoContent();
    }

    // accion de borrar usuaruiios
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var user = _users.Find(u => u.Id == id);
        if(user == null) {
            return NotFound();
        }

        // user.deleteDate = DateTime.Now;
        _users.Remove(user);
        return NoContent();
    }
}