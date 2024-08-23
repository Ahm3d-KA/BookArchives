using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookArchives.Models;

public class UserBooksModel
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string ArchiveUserName { get; set; }
    public string? BookName { get; set; }
    // public DateTime DateStarted { get; set; }
    // public DateTime DateFinished { get; set; }
    // public int Rating { get; set; }
    // public string? Notes { get; set; }
    // public ReadingStatusEnum ReadingStatus { get; set; }
}