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
        List<BookResponse> GetBooks(BookParameters bookParameters, string tags);
        Book GetBook(string id);
        BookResponse AddBook(CreateBookViewModel book);
        void DeleteBook(string id);
        BookResponse UpdateBook(UpdateBookViewModel book);
        MostResponse GetMostUsed();
        //BsonDocument GetMostUsed();
    }
}
