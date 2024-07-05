using System.ComponentModel.DataAnnotations;

namespace BookArchives.Models;

public class UserBooksModel
{
    [Key]
    [Required]
    public string Id { get; set; }
    public string ArchiveUserId { get; set; }
    public string BookId { get; set; }
    public DateTime DateStarted { get; set; }
    public DateTime DateFinished { get; set; }
    public int Rating { get; set; }
    public string? Notes { get; set; }
    public ReadingStatusEnum ReadingStatus { get; set; }
}