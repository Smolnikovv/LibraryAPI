using AutoMapper;
using LibraryAPI.Configs;
using LibraryAPI.Models.Borrower;
using LibraryAPI.Models.Genre;

namespace LibraryAPI.Services
{
    public interface IGenreService
    {
        List<GenreDto> GetAll();
        GenreDto GetById(int id);
        GenreDto GetByDescription(string description);
        int Create(CreateGenreDto dto);
        void Update(int id,UpdateGenreDto dto);
        void Delete(int id);
    }
    public class GenreService : IGenreService
    {

        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public GenreService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        public List<GenreDto> GetAll()
        {
            var genres = _databaseContext
                  .Genres
                  .ToList();

            if (genres == null) throw new NotImplementedException();

            var result = _mapper.Map<List<GenreDto>>(genres);

            return result;
        }

        public GenreDto GetByDescription(string description)
        {
            var genres = _databaseContext
                  .Genres
                  .Where(x => x.Description == description)
                  .ToList();

            if (genres == null) throw new NotImplementedException();

            var result = _mapper.Map<GenreDto>(genres);

            return result;
        }

        public GenreDto GetById(int id)
        {
            var genres = _databaseContext
                  .Genres
                  .Where(x => x.Id == id)
                  .FirstOrDefault();

            if (genres == null) throw new NotImplementedException();

            var result = _mapper.Map<GenreDto>(genres);

            return result;
        }

        public void Update(int id, UpdateGenreDto dto)
        {
            var genres = _databaseContext
                  .Genres
                  .Where(x => x.Id == id)
                  .FirstOrDefault();

            if (genres == null) throw new NotImplementedException();

            genres.Description = dto.Description ?? genres.Description;

            _databaseContext.SaveChanges();
        }
        public int Create(CreateGenreDto dto)
        {
            var genres = _mapper.Map<GenreDto>(dto);
            _databaseContext.Add(genres);
            _databaseContext.SaveChanges();
            return genres.Id;
        }

        public void Delete(int id)
        {
            var genres = _databaseContext
                   .Genres
                   .Where(x => x.Id == id)
                   .FirstOrDefault();

            if (genres == null) throw new NotImplementedException();

            _databaseContext.Remove(genres);
            _databaseContext.SaveChanges();
        }
    }
}
