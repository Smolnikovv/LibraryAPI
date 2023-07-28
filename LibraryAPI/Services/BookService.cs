using AutoMapper;
using LibraryAPI.Configs;
using LibraryAPI.Models.Book;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        BookDto GetById(int id);
        List<BookDto> GetByTitle(string title);
        List<BookDto> GetByAuthorId(int id);
        List<BookDto> GetByGenreId(int id);
        int Create(CreateBookDto dto);
        void Delete(int id);
        void Update(int id, UpdateBookDto dto);
    }
    public class BookService : IBookService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public BookService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public List<BookDto> GetAll()
        {
            var books = _databaseContext
                 .Books
                 .ToList();

            if (books == null) throw new NotImplementedException();

            var result = _mapper.Map<List<BookDto>>(books);

            return result;

        }

        public List<BookDto> GetByAuthorId(int id)
        {
            var books = _databaseContext
                  .Books
                  .Where(x => x.AuthorId == id)
                  .ToList();

            if (books == null) throw new NotImplementedException();

            var result = _mapper.Map<List<BookDto>>(books);

            return result;
        }

        public List<BookDto> GetByGenreId(int id)
        {
            var books = _databaseContext
                  .Books
                  .Where(x => x.GenreId == id)
                  .ToList();

            if (books == null) throw new NotImplementedException();

            var result = _mapper.Map<List<BookDto>>(books);

            return result;
        }

        public BookDto GetById(int id)
        {
            var books = _databaseContext
                  .Books
                  .Where(x => x.Id == id)
                  .FirstOrDefault();

            if (books == null) throw new NotImplementedException();

            var result = _mapper.Map<BookDto>(books);

            return result;
        }

        public List<BookDto> GetByTitle(string title)
        {
            var books = _databaseContext
                  .Books
                  .Where(x => x.Name == title)
                  .ToList();

            if (books == null) throw new NotImplementedException();

            var result = _mapper.Map<List<BookDto>>(books);

            return result;
        }

        public void Update(int id, UpdateBookDto dto)
        {
            var books = _databaseContext
                   .Books
                   .Where(x => x.Id == id)
                   .FirstOrDefault();

            if (books == null) throw new NotImplementedException();

            books.Name = dto.Name ?? books.Name;
            books.AuthorId = dto.AuthorId ?? books.AuthorId;
            books.GenreId = dto.GenreId ?? books.GenreId;

            _databaseContext.SaveChanges();
        }
        public int Create(CreateBookDto dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var books = _databaseContext
                   .Books
                   .Where(x => x.Id == id)
                   .FirstOrDefault();

            if (books == null) throw new NotImplementedException();

            _databaseContext.Remove(books);
            _databaseContext.SaveChanges();
        }
    }
}
