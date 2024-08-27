using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookArchives.Models;

public class UserBooksModel
{
    // Generates an id
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; init; }
    [MaxLength(100)]
    public string? ArchiveUserName { get; set; }
    [MaxLength(100)]
    public string? BookName { get; set; }
    // public DateTime DateStarted { get; set; }
    // public DateTime DateFinished { get; eset; }
    public int? Rating { get; set; }
    [MaxLength(1000)]
    public string? Notes { get; set; }
    [MaxLength(100)]
    // MAKE SURE INPUT REFLECTS THIS
    public string? ReadingStatus { get; set; }
}