using AutoMapper;
using LibraryAPI.Configs;
using LibraryAPI.Entities;
using LibraryAPI.Models.Book;
using LibraryAPI.Models.BorrowedBook;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public interface IBorrowedBookService
    {
        List<BorrowedBookDto> GetByBorrower(int id);
        BorrowedBookDto GetByBookId(int id);
        void Create(CreateBorrowedBookDto dto);
        void Delete(int borrowerId);
    }
    public class BorrowedBookService : IBorrowedBookService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public BorrowedBookService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public BorrowedBookDto GetByBookId(int id)
        {
            var books = _databaseContext
                 .BorrowedBooks
                 .Include(x => x.Book)
                 .Include(x => x.Borrower)
                 .Where(x => x.BookId == id)
                 .FirstOrDefault();

            if (books == null) throw new NotImplementedException();

            var result = _mapper.Map<BorrowedBookDto>(books);

            return result;
        }

        public List<BorrowedBookDto> GetByBorrower(int id)
        {
            var books = _databaseContext
                 .BorrowedBooks
                 .Include(x => x.Book)
                 .Include(x => x.Borrower)
                 .Where(x => x.BorrowerId == id)
                 .ToList();

            if (books == null) throw new NotImplementedException();

            var result = _mapper.Map<List<BorrowedBookDto>>(books);

            return result;
        }
        public void Create(CreateBorrowedBookDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            _databaseContext.Books.Add(book);
            _databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var books = _databaseContext
                 .BorrowedBooks
                 .Include(x => x.Borrower)
                 .Where(x => x.BorrowerId == id)
                 .ToList();

            if (books == null) throw new NotImplementedException();

            _databaseContext.Remove(books);
            _databaseContext.SaveChanges();
        }
    }
}
