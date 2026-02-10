namespace Tarea1;

public abstract class CommunityMember{
    public string Role{get; set;}
    public DateTime Birthdate{get; set;}
    public DateTime EntryDate{get; set;}
    public DateTime DepartureDate{get; set;}
    public string Cedula{get; set;} = string.Empty;
    public string Email{get; set;} = string.Empty;
    public string FirstName{get; set;} = string.Empty;
    public string LastName{get; set;} = string.Empty;
}