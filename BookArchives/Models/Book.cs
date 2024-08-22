using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookArchives.Models;

public class Book
{
    [Key, Column(Order = 0)]
    public UserBooksModel UserBook { get; set; }
    public string? Notes { get; set; }
}