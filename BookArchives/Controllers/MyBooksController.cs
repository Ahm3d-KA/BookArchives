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
        OpenLibraryBook userBook = await SearchBooksAsync();
        return View("Add", userBook);
        
    }
    public async Task<OpenLibraryBook> SearchBooksAsync()
    {
        var client = _httpClientFactory.CreateClient();
        string url = $"https://openlibrary.org/search.json?title=diary+of+a+wimpy+kid&limit=1&fields=author_name,cover_i,ddc_sort,title,id_goodreads,subject,number_pages_median,ratings_average,first_publish_year,number_of_pages_median";
    
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
    // public async Task<JsonElement> FetchJsonAsync(string url)
    // {
    //     var client = _httpClientFactory.CreateClient();
    //     var response = await client.GetAsync(url);
    //     if (response.IsSuccessStatusCode)
    //     {
    //         var jsonString = await response.Content.ReadAsStringAsync();
    //         using var doc = JsonDocument.Parse(jsonString);
    //         return doc.RootElement.Clone();
    //     }
    //     else
    //     {
    //         // Handle the case where the API call was not successful
    //         throw new HttpRequestException($"Request to {url} failed with status code {response.StatusCode}");
    //     }
    // }

}
