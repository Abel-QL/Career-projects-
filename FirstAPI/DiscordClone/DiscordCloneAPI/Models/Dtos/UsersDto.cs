namespace DiscordClone.Models;

public class UsersDto{
    public int Id {get; set;}
    public string UserName {get; set;} = string.Empty;
    public string Email {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
    public bool IsAdmin {get; set;} = false;
    public bool IsBot {get; set;} = false;
    public bool IsActive {get; set;} = true;
    public string StateActivity {get; set;}
    public bool IsSuscribe {get; set;} = false;

    // relacion con servers
    public int ServerId {get; set;}
    public Servers server {get; set;}
}
// suscripcion, miembros, descripcion, perfil del usuario