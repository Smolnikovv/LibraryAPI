using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models.Author;

namespace LibraryAPI.Configs
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<CreateAuthorDto, Author>();
        }
    }
}
