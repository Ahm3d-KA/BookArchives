using System.Collections;
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
        List<UserBooksModel> objUserBooksList = new List<UserBooksModel>();
        foreach (UserBooksModel item in _db.ArchiveDb)
        {
            if (item.ArchiveUserName == HttpContext.User.Identity.Name)
            {
                objUserBooksList.Add(item);
            }
        }
        return View(objUserBooksList);
    }
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> FindPOST(string title)
    {
        if (title == null)
        {
            return View("Add");
        }
        // replaces spaces with +
        string formattedTitle = title.Replace(" ", "+");
        
        
        OpenLibraryBook userBook = await SearchBooksAsync(formattedTitle);
        // makes sure it doesn't reference something that is empty 
        if (userBook.docs != null)
        {
            userBook.bookCoverUrl = CreateCoverUrl(userBook.docs[0].cover_i);
        }

        CombinedUserBookOpenLibrary combinedUserBookOpenLibrary = new CombinedUserBookOpenLibrary();
        combinedUserBookOpenLibrary.OpenLibraryBook = userBook;
        return View("Add", combinedUserBookOpenLibrary);
        
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddPost(UserBooksModel userBook)
    {
        // book wasn't found
        if (userBook.BookName == null)
        {
            return Json(new { status = "error", message = "Book not found" });
        }
        bool existsAlready = false;
        // userBook.ArchiveUserName = User.FindFirstValue(ClaimTypes.NameIdentifier);
        // see if database operation works
        try
        {
            userBook.ArchiveUserName = HttpContext.User.Identity.Name;
            
            foreach (UserBooksModel item in _db.ArchiveDb)
            {
                if (item.ArchiveUserName == userBook.ArchiveUserName && item.BookName == userBook.BookName)
                {
                    existsAlready = true;
                }
            }

            if (!existsAlready)
            {
                _db.ArchiveDb.Add(userBook);
                _db.SaveChanges();
            }
            
        }
        catch (Exception e)
        {
            return Json(new { status = "error", message = e.Message });
        }
        return RedirectToAction("Index", "MyBooks");
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
