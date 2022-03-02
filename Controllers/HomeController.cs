using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.Services;

namespace bookish.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
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
        var bookService = new BookService();
        var books = bookService.GetAllBooks();
       /* {
             new Book{
                Title = "Harry Potter And The Prisoner Of Azkaban",
                YearPublished = 1999,
                Author = "JK Rowling",
                ImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1630547330l/5._SY475_.jpg",
                Blurb = "Sirius Black turns out to be a good guy despite his name and house"
            },
            new Book{
                Title = "Harry Potter And The Chamber of Secrets",
                YearPublished = 1997,
                Author = "JK Rowling",
                ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51mFoFmu0EL._SX335_BO1,204,203,200_.jpg",
                Blurb = "Harry talks to some snakes"
            },
            new Book{
                Title = "Harry Potter And The Deathly Hallows",
                YearPublished = 2006,
                Author = "JK Rowling",
                ImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1474171184l/136251._SY475_.jpg",
                Blurb = "Harry finds some hawcruxes, whatever they are"
            }, 
        };*/
        return View(books);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
