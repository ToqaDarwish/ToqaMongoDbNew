using AutoMapper;
using System.Collections.Generic;
using ToqaMongoDbNew.Exceptions;
using ToqaMongoDbNew.Models;
using ToqaMongoDbNew.Repository;

namespace ToqaMongoDbNew.Services.BookServices
{
    public class BookServices : IBookServices
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookServices(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public BookResponse AddBook(CreateBookViewModel book)
        {
            if(book.BookName == "" && book.Description == "" && book.ListOfTags.Count == 0)
            {
                throw new CustomException();
            }
            else if(book.Description == "")
            {
                throw new CustomException(true);
            }
            else if(book.BookName == "")
            {
                throw new CustomException(book.BookName);
            }
            else if(book.ListOfTags.Count == 0)
            {
                throw new CustomException(book.ListOfTags);
            }
            else
                return _mapper.Map<Book, BookResponse>(_bookRepository.AddBook(book));
        }

        public ApiResponse DeleteBook(string id)
        {
            var findId = _bookRepository.FindId(id);
            if (findId == false)
                return new ApiResponse { Status = "Failed", Message = "Id is not Found or Invalid ,, Check again your Entered Id" };
            else
            {
                _bookRepository.DeleteBook(id);
                return new ApiResponse { Status = "Successed", Message = "Book is Deleted Successfully" };
            }
        }

        public List<BookResponse> GetBooks(PageParameters bookParameters, string tags)
        {
            return _bookRepository.GetBooks(bookParameters, tags);
        }
            
        public Book GetBook(string id) => _bookRepository.GetBook(id);

        public BookResponse UpdateBook(UpdateBookViewModel newBook)
        {
            return _mapper.Map<Book, BookResponse>(_bookRepository.UpdateBook(newBook));
        }

        public MostResponse GetMostUsed()
        {
            return _bookRepository.GetMostUsedAggregation();
        }
    }
}
