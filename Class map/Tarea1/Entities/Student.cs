using System.Data.SqlTypes;

namespace Tarea1;

public class Student: CommunityMember {
    public int id {get; set;} 
    public int StudentId{get; set;}
    public string carreer{get; set;}
    public bool IsActive{get; set;}  = true;
    public bool isFormerStudent{get; set;} = false;
    public string calification {get; set;} = string.Empty;
}