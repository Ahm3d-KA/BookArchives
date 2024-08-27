using BookArchives.Models;
using Microsoft.EntityFrameworkCore;

namespace BookArchives.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<UserBooksModel> ArchiveDb { get; set; }


    
}

// 