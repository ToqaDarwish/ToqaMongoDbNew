using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToqaMongoDbNew.Helper;
using ToqaMongoDbNew.Models;
using ToqaMongoDbNew.Services.BookServices;
using ToqaPOC.ViewModels;

namespace ToqaMongoDbNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices _bookServices;

        public BooksController(IBookServices bookService)
        {
            _bookServices = bookService;
        }

        [HttpPut]
        [Route("Add")]
        public IActionResult Add(CreateBookViewModel book)
        {
            return Ok(SuccessHelper.Warp(_bookServices.AddBook(book)));
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult UpdateBook(UpdateBookViewModel book)
        {
            return Ok(SuccessHelper.Warp(_bookServices.UpdateBook(book)));
        }

        [HttpPost]
        //[Route("Delete")]
        public IActionResult DeleteBook(string id)
        {
            return Ok(_bookServices.DeleteBook(id));
        }

        [HttpGet]
        public IActionResult GetBooks([FromQuery] PageParameters booksParameters, [FromQuery] string tags)
        {
            var books = _bookServices.GetBooks(booksParameters,tags);
            return Ok(books);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult GetBook(string id)
        {
            return Ok(_bookServices.GetBook(id));
        }
        [HttpGet]
        [Route("GetMostUsed")]
        public IActionResult GetMostUsed()
        {
            return Ok(_bookServices.GetMostUsed());
        }

    }
}
