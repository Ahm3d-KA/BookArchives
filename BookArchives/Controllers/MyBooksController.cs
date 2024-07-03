using System.Collections;
using BookArchives.Data;
using BookArchives.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookArchives.Controllers;

public class MyBooksController : Controller
{
    private readonly ApplicationDbContext _db;

    public MyBooksController(ApplicationDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        IEnumerable<UserBooksModel> objUserBooksList = _db.ArchiveDb;
        return View(objUserBooksList);
    }
}