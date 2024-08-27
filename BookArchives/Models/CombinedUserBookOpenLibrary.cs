namespace BookArchives.Models;

public class CombinedUserBookOpenLibrary
{
    public OpenLibraryBook? OpenLibraryBook { get; set; }
    public UserBooksModel? UserBook { get; set; }
    public bool? Found { get; set; }
}