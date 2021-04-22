using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToqaMongoDbNew.Models;

namespace ToqaMongoDbNew.Mapping
{
    public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<UpdateBookViewModel, Book>();
            CreateMap<Book, BookResponse>()
                .ForMember(dest => dest.Tags,m => m.MapFrom(src => string.Join(",", src.ListOfTags)));
            CreateMap<Book, MostResponse>();
            //CreateMap<List<Book>, List<BookResponse>>();
            //CreateMap<List<Book>, BookResponse>();
            //        CreateMap<Book, CreateBookViewModel>()
            //.ForMember(dest => dest.Tags,
            //m => m.MapFrom(src => src.ListOfTags.ToString()));
        }
    }
}
