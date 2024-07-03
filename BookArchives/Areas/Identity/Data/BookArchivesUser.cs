using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookArchives.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BookArchivesUser class
public class BookArchivesUser : IdentityUser
{
    public string UserName { get; set; }   
    // public string LastName { get; set; }
}

