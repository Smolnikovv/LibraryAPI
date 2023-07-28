using AutoMapper;
using LibraryAPI.Configs;
using LibraryAPI.Entities;
using LibraryAPI.Models.Author;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public interface IAuthorService
    {
        List<AuthorDto> GetAll();
        AuthorDto GetById(int id);
        List<AuthorDto> GetByName(string name);
        List<AuthorDto> GetBySurname(string surname);
        int Create(CreateAuthorDto dto);
        void Update(int id, UpdateAuthorDto dto);
        void Delete(int id);
    }
    public class AuthorService : IAuthorService
    {

        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public AuthorService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        
        public List<AuthorDto> GetAll()
        {
            var authors = _databaseContext
                .Authors
                .ToList();

            if(authors is null)  throw new NotImplementedException(); 

            var result = _mapper.Map<List<AuthorDto>>(authors);
            return result;
        }

        public AuthorDto GetById(int id)
        {
            var authors = _databaseContext
                .Authors
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (authors is null) throw new NotImplementedException();

            var result = _mapper.Map<AuthorDto>(authors);
            return result;
        }

        public List<AuthorDto> GetByName(string name)
        {
            var authors = _databaseContext
                .Authors
                .Where (x => x.Name == name)
                .ToList();

            if (authors is null) throw new NotImplementedException();

            var result = _mapper.Map<List<AuthorDto>>(authors);
            return result;
        }

        public List<AuthorDto> GetBySurname(string surname)
        {
            var authors = _databaseContext
                .Authors
                .Where(x => x.Surname == surname)
                .ToList();

            if (authors is null) throw new NotImplementedException();

            var result = _mapper.Map<List<AuthorDto>>(authors);
            return result;
        }

        public void Update(int id,UpdateAuthorDto dto)
        {
            var authors = _databaseContext
                .Authors
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if(authors is null) throw new NotImplementedException();

            authors.Name = dto.Name ?? authors.Name;
            authors.Surname = dto.Surname ?? authors.Surname;
            _databaseContext.SaveChanges();
        }
        public int Create(CreateAuthorDto dto)
        {
            var author = _mapper.Map<Author>(dto);
            _databaseContext.Authors.Add(author);
            _databaseContext.SaveChanges();

            return author.Id;
        }

        public void Delete(int id)
        {
            var authors = _databaseContext
                .Authors
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (authors is null) throw new NotImplementedException();

            _databaseContext.Remove(authors);
            _databaseContext.SaveChanges();
        }

    }
}
