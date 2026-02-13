namespace DiscordClone.Models;

public class Servers{
    public int Id {get; set;}
    public string NameServer {get; set;} = string.Empty;
    public List<String> ServerMembers {get; set;} = new List<string>();
    public int NumberMembers => ServerMembers.Count;
    public List<String> Channels {get; set;} = new List<string>();
    public List<String> ServerRole {get; set;} = new List<string>();
    public bool IsPublic {get; set;} = false;
    public bool IsActive {get; set;} = true;
    public DateTime CreateDate {get; set;}
    public DateTime UpdateDate {get; set;}
    public DateTime DeleteDate {get; set;}
    public int BoostAmount {get; set;}
}