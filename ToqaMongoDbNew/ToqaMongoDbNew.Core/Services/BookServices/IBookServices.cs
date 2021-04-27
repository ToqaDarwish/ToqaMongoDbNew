using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToqaMongoDbNew.Models;

namespace ToqaMongoDbNew.Services.BookServices
{
    public interface IBookServices
    {
        List<BookResponse> GetBooks(PageParameters bookParameters, string tags);
        Book GetBook(string id);
        BookResponse AddBook(CreateBookViewModel book);
        ApiResponse DeleteBook(string id);
        BookResponse UpdateBook(UpdateBookViewModel book);
        MostResponse GetMostUsed();

    }
}
