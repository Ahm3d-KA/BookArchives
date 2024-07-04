using System.Collections;
using System.Text.Json;
using BookArchives.Data;
using BookArchives.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookArchives.Controllers;

public class MyBooksController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IHttpClientFactory _httpClientFactory;

    public MyBooksController(ApplicationDbContext db, IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _db = db;
    }
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<UserBooksModel> objUserBooksList = _db.ArchiveDb;
        return View(objUserBooksList);
    }
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPOST(string title)
    {
        // replaces spaces with +
        string formattedTitle = title.Replace(" ", "+");
        
        
        OpenLibraryBook userBook = await SearchBooksAsync(formattedTitle);
        // makes sure it doesn't reference something that is empty 
        if (userBook.docs != null)
        {
            userBook.bookCoverUrl = CreateCoverUrl(userBook.docs[0].cover_i);
        }
        return View("Add", userBook);
        
    }
    // returns information about a book after the title is inputted in an object
    public string CreateCoverUrl(int coverI)
    {
        string stringCoverI = coverI.ToString();
        string url = "https://covers.openlibrary.org/b/id/" + stringCoverI + "-L.jpg";
        return url;
    }
    public async Task<OpenLibraryBook> SearchBooksAsync(string userTitle)
    {
        var client = _httpClientFactory.CreateClient();
        string url = $"https://openlibrary.org/search.json?title="+userTitle+"&limit=3&fields=author_name,cover_i,ddc_sort,title,id_goodreads,subject,number_pages_median,ratings_average,first_publish_year,number_of_pages_median";
    
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var searchResult = System.Text.Json.JsonSerializer.Deserialize<OpenLibraryBook>(content);
            return searchResult;
        }
        else
        {
            // Handle the case where the API call was not successful
            return null;
        }
    }


}
