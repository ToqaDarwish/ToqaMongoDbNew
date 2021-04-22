using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToqaMongoDbNew.Models;

namespace ToqaMongoDbNew.Repository
{
    public interface IBookRepository
    {
        List<BookResponse> GetBooks(BookParameters bookParameters, string tags);
        Book GetBook(string id);
        Book AddBook(CreateBookViewModel book);
        void DeleteBook(string id);
        Book UpdateBook(UpdateBookViewModel book);
        MostResponse GetMostUsed();
        MostResponse GetMostUsedMongoExportation();
        MostResponse GetMostUsedAggregation();
    }
}
