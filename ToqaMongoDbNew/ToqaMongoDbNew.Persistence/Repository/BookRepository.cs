using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using ToqaMongoDbNew.Models;
using ToqaMongoDbNew.MongoSetting;

namespace ToqaMongoDbNew.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IMapper _mapper;

        public BookRepository(IMongoDatabaseSettings settings, IMapper mapper)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
            _mapper = mapper;
        }
        public Book AddBook(CreateBookViewModel book)
        {
            var newbook = _mapper.Map<CreateBookViewModel, Book>(book);
            _books.InsertOne(newbook);
            return newbook;
        }

        public Book UpdateBook(UpdateBookViewModel book)
        {
            var oldBook = _books.Find(b => b.Id == book.Id).FirstOrDefault();
            var new_Book = _mapper.Map<UpdateBookViewModel, Book>(book, oldBook);

            _books.ReplaceOne(b => b.Id == oldBook.Id, new_Book);
            return new_Book;
        }

        public bool FindId(string id)
        {
            var Id = new ObjectId();
            if(!ObjectId.TryParse(id,out Id))
            {
                return false;
            }
            else
            {
                var found = _books.Find(book => book.Id == id).FirstOrDefault();
                if (found == null)
                    return false;
                else
                    return true;
            }
        }
        public void DeleteBook(string id)
        {
            _books.DeleteOne(book => book.Id == id);
        }

        public Book GetBook(string id) => _books.Find(book => book.Id == id).First();

        public List<BookResponse> GetBooks(PageParameters bookParameters, string tags)
        {
            var books = _books.Find(book => true)
                .SortByDescending(b => b.Id)
                .Skip((bookParameters.PageNumber - 1) * bookParameters.PageSize)
                .Limit(bookParameters.PageSize)
                .ToList();
            if (tags != null)
            {
                books = _books.Find(b => b.ListOfTags.Contains(tags)).SortByDescending(b => b.Id)
                .Skip((bookParameters.PageNumber - 1) * bookParameters.PageSize)
                .Limit(bookParameters.PageSize).ToList();
            }
            else
            {
                var resBook1 = _mapper.Map<List<BookResponse>>(books);
                return resBook1;
            }
            var resBook = _mapper.Map<List<BookResponse>>(books);
            return resBook;
        }

        public MostResponse GetMostUsed()
        {
            //var books = _books.Find(book => true).ToList();
            var allTags = _books.AsQueryable().SelectMany(a => a.ListOfTags);
            var query = allTags.GroupBy(x => x.ToString())
            .Select(group => new { Tags = group.Key, Count = group.Count() })
            .OrderByDescending(x => x.Count);
            //var query = _books.AsQueryable().GroupBy(x => x.ListOfTags)
            //.Select(group => new { Tags = group.Key, Count = group.Count() })
            //.OrderByDescending(x => x.Count);

            var item = query.First();

            var mostUsed = new MostResponse
            {
                Tag = item.Tags,
                Count = item.Count
            };
            return mostUsed;
        }

        public MostResponse GetMostUsedAggregation()
        {
            var query = _books.Aggregate()
                .Unwind<Book, UnwindBook>(a => a.ListOfTags)
                .Group(e => e.ListOfTags, g => new { Tag = g.Key, Count = g.Count() })
                .Sort("{Count: -1}");

            var doc = query.First();
            var mostUsed = new MostResponse
            {
                Tag = doc.Tag,
                Count = doc.Count
            };
            return mostUsed;
        }

        public MostResponse GetMostUsedMongoExportation()
        {
            BsonDocument[] array = new BsonDocument [5]
            {
                new BsonDocument("$unwind",
                new BsonDocument("path", "$ListOfTags")),
                new BsonDocument("$project",
                new BsonDocument
                    {
                        { "ListOfTags", "$ListOfTags" },
                        { "_id", 0 }
                    }),
                new BsonDocument("$group",
                new BsonDocument
                    {
                        { "_id",
                new BsonDocument("$toString", "$ListOfTags") },
                        { "__agg0",
                new BsonDocument("$sum", 1) }
                    }),
                new BsonDocument("$project",
                new BsonDocument
                    {
                        { "Tag", "$_id" },
                        { "Count", "$__agg0" },
                        { "_id", 0 }
                    }),
                new BsonDocument("$sort",
                new BsonDocument("Count", -1))
            };

            var mostUsed = _books.Aggregate().AppendStage<MostResponse>(array[0])
                .AppendStage<MostResponse>(array[1])
                .AppendStage<MostResponse>(array[2])
                .AppendStage<MostResponse>(array[3])
                .AppendStage<MostResponse>(array[4]).First();

            return mostUsed;

        }
    }
}
