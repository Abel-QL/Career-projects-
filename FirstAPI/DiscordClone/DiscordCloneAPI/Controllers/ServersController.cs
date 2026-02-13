using Microsoft.AspNetCore.Mvc;
using DiscordClone.Models;

namespace DiscordClone.Controllers;

[ApiController]
[Route("api/Servers")]
public class ServersController : ControllerBase{
    private static readonly List<Servers> _servers = new List<Servers> {
        new Servers {
            Id = 1,
            NameServer = "Servidor de pappolo",
            IsPublic = true,
            BoostAmount = 3,
            IsActive = false,
            ServerMembers = new List<string> {"Papolo", "papolo admin", "La novia de papolo"},
            Channels = new List<string> {"General", "Mmees", "Voice general"},
            ServerRole = new List<string> {"Admin", "Miembro normal", "Jugador porfesional"},
            CreateDate = DateTime.Now.AddDays(-13),
            UpdateDate = DateTime.Now,
            DeleteDate = DateTime.Now.AddDays(-2)
        },
        new Servers {
            Id = 2,
            NameServer = "El Rincón del Programador",
            IsPublic = true,
            BoostAmount = 15,
            ServerMembers = new List<string> {"Linus Torvalds", "Ada Lovelace", "Junior Estresado"},
            Channels = new List<string> {"bugs-y-llantos", "recursos-pdf", "cafeteria-virtual"},
            ServerRole = new List<string> {"Senior", "Moderador", "Stack Overflow God"},
            CreateDate = DateTime.Now.AddMonths(-6),
            UpdateDate = DateTime.Now,
            DeleteDate = DateTime.MinValue
        },
        new Servers {
            Id = 3,
            NameServer = "Gamer Zone: Solo Pro-Players",
            IsPublic = false,
            BoostAmount = 0,
            ServerMembers = new List<string> {"NoobMaster69", "TheGrefg", "Un bot cualquiera"},
            Channels = new List<string> {"lobby", "estrategias", "torneos-diarios"},
            ServerRole = new List<string> {"MVP", "Suscrito", "Baneado temporalmente"},
            CreateDate = DateTime.Now.AddDays(-30),
            UpdateDate = DateTime.Now.AddDays(-5),
            DeleteDate = DateTime.MinValue
        }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Servers>> GetAllServers(){
        var response = _servers.Select(s => new ServersDto {Id = s.Id, NameServer = s.NameServer, IsPublic = s.IsPublic, BoostAmount = s.BoostAmount, IsActive = s.IsActive, ServerMembers = s.ServerMembers, Channels = s.Channels, ServerRole = s.ServerRole,});
        return Ok(response);
    }

    [HttpGet("{Id}")]
    public IActionResult Get(int Id){
        var server = _servers.Find(s => s.Id == Id);
        if(server == null)
            return NotFound();
        return Ok(server);
    }

    [HttpPost]
    public IActionResult Post([FromBody] ServersDto request){
        request.Id = _servers.Max(s => s.Id) + 1;
        var server = new Servers {
            NameServer = request.NameServer,
            IsPublic = request.IsPublic,
            BoostAmount = request.BoostAmount,
            ServerMembers = request.ServerMembers,
            Channels = request.Channels,
            ServerRole = request.ServerRole,
            IsActive = request.IsActive,
            CreateDate = DateTime.Now,
            UpdateDate = DateTime.Now,
            DeleteDate = DateTime.MinValue
        };

        _servers.Add(server);
        return CreatedAtAction(nameof(Get), new {Id = request.Id}, request);
    }

    [HttpPut("{Id}")]
    public IActionResult Put(int Id, [FromBody] ServersDto request){
        var server = _servers.FirstOrDefault(s => s.Id == Id);
        if(server == null) {
            return NotFound();
        }

        server.NameServer = request.NameServer;
        server.UpdateDate = DateTime.Now;
        server.DeleteDate = DateTime.MinValue;
        server.Channels = request.Channels;
        server.IsPublic = request.IsPublic;
        server.BoostAmount = request.BoostAmount;
        server.IsActive = request.IsActive;
        server.ServerMembers = request.ServerMembers;
        server.ServerRole = request.ServerRole;
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id){
        var server = _servers.Find(s => s.Id == Id);
        if(server == null) {
            return NotFound();
        }

        _servers.Remove(server);
        return NoContent();
    }
}