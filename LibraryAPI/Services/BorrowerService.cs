using AutoMapper;
using LibraryAPI.Configs;
using LibraryAPI.Entities;
using LibraryAPI.Models.Book;
using LibraryAPI.Models.Borrower;

namespace LibraryAPI.Services
{
    public interface IBorrowerService
    {
        List<BorrowerDto> GetAll();
        BorrowerDto GetById(int id);
        List<BorrowerDto> GetByName(string name);
        List<BorrowerDto> GetBySurname(string surname);
        int Create(CreateBorrowerDto dto);
        void Update(int id, UpdateBorrowerDto dto);
        void Delete(int id);
    }
    public class BorrowerService : IBorrowerService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public BorrowerService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public List<BorrowerDto> GetAll()
        {
            var borrower = _databaseContext
                 .Borrowers
                 .ToList();

            if (borrower == null) throw new NotImplementedException();

            var result = _mapper.Map<List<BorrowerDto>>(borrower);

            return result;
        }

        public BorrowerDto GetById(int id)
        {
            var borrower = _databaseContext
                 .Borrowers
                 .Where(x => x.Id == id)
                 .FirstOrDefault();

            if (borrower == null) throw new NotImplementedException();

            var result = _mapper.Map<BorrowerDto>(borrower);

            return result;
        }

        public List<BorrowerDto> GetByName(string name)
        {
            var borrower = _databaseContext
                 .Borrowers
                 .Where(x => x.Name == name)
                 .ToList();

            if (borrower == null) throw new NotImplementedException();

            var result = _mapper.Map<List<BorrowerDto>>(borrower);

            return result;
        }

        public List<BorrowerDto> GetBySurname(string surname)
        {
            var borrower = _databaseContext
                  .Borrowers
                  .Where(x => x.Surname == surname)
                  .ToList();

            if (borrower == null) throw new NotImplementedException();

            var result = _mapper.Map<List<BorrowerDto>>(borrower);

            return result;
        }

        public void Update(int id, UpdateBorrowerDto dto)
        {
            var borrower = _databaseContext
                 .Borrowers
                 .Where(x => x.Id == id)
                 .FirstOrDefault();

            if (borrower == null) throw new NotImplementedException();

            borrower.Name = dto.Name ?? borrower.Name;
            borrower.Surname = dto.Surname ?? borrower.Surname;
            borrower.DateOfBirth = dto.DateOfBirth ?? borrower.DateOfBirth;

            _databaseContext.SaveChanges();
        }

        public int Create(CreateBorrowerDto dto)
        {
            var borrower = _mapper.Map<Borrower>(dto);
            _databaseContext.Add(borrower);
            _databaseContext.SaveChanges();
            return borrower.Id;
        }

        public void Delete(int id)
        {
            var borrower = _databaseContext
                 .Borrowers
                 .Where(x => x.Id == id)
                 .ToList();

            if (borrower == null) throw new NotImplementedException();

            _databaseContext.Remove(borrower);
            _databaseContext.SaveChanges();
        }
    }
}
