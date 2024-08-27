
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace BookArchives.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BookArchivesUser class
public class BookArchivesUser : IdentityUser
{
    [MaxLength(100)]
    public string? AccountName { get; set; }   
    // public string LastName { get; set; }
}

