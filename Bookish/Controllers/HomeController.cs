using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.Services;
using bookish.Models.Database;
using bookish.Repositories;

namespace bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IBookService _bookService;
    private readonly BookishContext _context;

    public HomeController(ILogger<HomeController> logger, IBookService bookService, BookishContext context)
    {
        _logger = logger;
        _bookService = bookService;
        _context = context;
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
    public IActionResult CreateBook([FromForm] BookDbModel book)
    {
        var newBookEntry = _context.Books.Add(book).Entity;
        _context.SaveChanges();
 
        return RedirectToAction("BookList");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook([FromRoute] int id)
    {
        var book = _context.Books
                    .Single(book => book.Id == id);

        _context.Books.Remove(book);
        _context.SaveChanges();
 
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
