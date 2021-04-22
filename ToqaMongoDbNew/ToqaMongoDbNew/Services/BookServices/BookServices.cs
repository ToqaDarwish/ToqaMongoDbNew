﻿using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToqaMongoDbNew.Models;
using ToqaMongoDbNew.MongoSetting;
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
            return _mapper.Map<Book, BookResponse>(_bookRepository.AddBook(book));
        }

        public void DeleteBook(string id)
        {
            _bookRepository.DeleteBook(id);
        }

        public List<BookResponse> GetBooks(BookParameters bookParameters, string tags)
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
