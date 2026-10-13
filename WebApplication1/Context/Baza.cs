using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context;

public class Baza : DbContext
{    public Baza(DbContextOptions<Baza> options) : base(options)
    {
    }
    public DbSet<Tasks> Tasks { get; set; }
}