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
    private readonly IMemberService _memberService;

    public HomeController(ILogger<HomeController> logger, IBookService bookService, IAuthorService authorService, IMemberService memberService)
    {
        _logger = logger;
        _bookService = bookService;
        _authorService = authorService;
        _memberService = memberService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpGet("Members")]
    public IActionResult Members()
    {
        var members = _memberService.GetAllMembers();

        return View(members);
    }

    public IActionResult BookList()
    {
        var books = _bookService.GetAllBooks();
       
        return View(books);
    }
    [HttpGet("/Book/Create")]
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

    [HttpPost]
    public IActionResult CreateAuthor([FromForm] AuthorDbModel author)
    {
        _authorService.CreateAuthor(author);
 
        return Ok();
    }

    [HttpDelete("/Book/{id}")]
    public IActionResult DeleteBook([FromRoute] int id)
    {
        _bookService.DeleteBook(id);
 
        return Ok();
    }

    [HttpDelete("/Author/{id}")]
    public IActionResult DeleteAuthor([FromRoute] int id)
    {
        _authorService.DeleteAuthor(id);
 
        return Ok();
    }
    [HttpPost]
    public IActionResult CreateMember([FromForm] MemberDbModel member)
    {
        _memberService.CreateMember(member);
 
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
