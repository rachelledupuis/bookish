using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.Services;
using bookish.Models.Database;

namespace bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IBookService _bookService;

    public HomeController(ILogger<HomeController> logger, IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Members()
    {
        var memberService = new MemberService();
        var members = memberService.GetAllMembers();
        return View(members);
    }

    public IActionResult BookList()
    {
        var books = _bookService.GetAllBooks();
       
        return View(books);
    }

    public IActionResult CreateBook()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateBook(BookDbModel book)
    {
        string isbn = book.Isbn;
        string title = book.Title;
        string blurb = book.Blurb;
        int yearPublished = book.YearPublished;
        string imageUrl = book.ImageUrl;
        AuthorDbModel author = book.Author;
 
        return Content($"This is your book title: {book.Title}");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
