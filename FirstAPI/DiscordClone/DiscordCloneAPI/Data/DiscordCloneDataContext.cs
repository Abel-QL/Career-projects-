using Microsoft.EntityFrameworkCore;

namespace DiscordClone.Data;

public class DiscordCloneDataContext : DbContext{
    public DiscordCloneDataContext(DbContextOptions<DiscordCloneDataContext> options)
    : base(options){
    }
}