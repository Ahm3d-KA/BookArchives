using System.ComponentModel.DataAnnotations;

namespace BookArchives.Models;

public class UserBooksModel
{
    [Key]
    [Required]
    public string Id { get; set; }
    public string ArchiveUserId { get; set; }
    public string BookId { get; set; }
    public DateTime DateRead { get; set; }
    public int Rating { get; set; }
    public string FavouriteQuote { get; set; }
}