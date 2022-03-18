using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.Services;
using bookish.Models.Database;
using bookish.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using bookish.Models.Request;

namespace bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    private readonly BookishContext _context;

    public HomeController(ILogger<HomeController> logger, IBookService bookService, BookishContext context, IAuthorService authorService)
    {
        _logger = logger;
        _bookService = bookService;
        _context = context;
        _authorService = authorService;
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
        var authors = _authorService.GetAllAuthors();
        ViewBag.authors = authors.Select(a => new SelectListItem 
            {
                Value = a.Id.ToString(),
                Text = a.Name,
            });
        return View();
    }

    [HttpPost]
    public IActionResult CreateBook([FromForm] CreateBookRequest book)
    {
        _bookService.CreateBook(book);
 
        return RedirectToAction("BookList");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook([FromRoute] int id)
    {
        var book = _context.Books.Single(book => book.Id == id);

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
