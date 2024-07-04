namespace BookArchives.Models;

public class OpenLibraryBook
{
    public int numFound { get; set; }
    public int start { get; set; }  
    public bool numFoundExact { get; set; }
    public List<Document> docs { get; set; }
    
    public int num_found { get; set; }
    public string q { get; set; }
    public int? offset { get; set; }
}

// "numFound": 145,
// "start": 0,
// "numFoundExact": true,
// "docs": [

// "num_found": 145,
// "q": "",
// "offset": null