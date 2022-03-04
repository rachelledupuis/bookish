using NUnit.Framework;
using System.Collections.Generic;
using FakeItEasy;
using bookish.Services;
using bookish.Repositories;
using bookish.Models.Database;

namespace Bookish.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BookService_ConvertsDbModelsToClasses()
    {
        // Arrange
        var fakeBookRepo = A.Fake<IBookRepo>();
        A.CallTo(() => fakeBookRepo.GetAllBooks()).Returns(
            new List<BookDbModel>
            {
                new BookDbModel
                {
                    Id = 1,
                    Isbn = "1234567890123",
                    Title = "The Dispossessed",
                    Blurb = "A great sci-fi book about things",
                    YearPublished = 2021,
                    ImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1353467455l/13651.jpg",
                    Author = new AuthorDbModel
                        {Name = "Ursula K. Le Guin"}
                },
                new BookDbModel
                {
                    Id = 2,
                    Isbn = "1234567890124",
                    Title = "Harry Potter",
                    Blurb = "A book about a young wizard",
                    YearPublished = 1995,
                    ImageUrl = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1353467455l/13651.jpg",
                    Author = new AuthorDbModel
                        {Name = "JK Rowling"}
                },
            }
        );
        var service = new BookService(fakeBookRepo);

        // Act
        var books = service.GetAllBooks();

        // Assert
        Assert.That(books, Has.Exactly(2).Items);
        Assert.That(books[1].Title, Is.EqualTo("Harry Potter"));
    }
}