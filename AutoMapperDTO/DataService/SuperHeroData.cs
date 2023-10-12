using AutoMapper;
using AutoMapperDTO.Entities;

namespace AutoMapperDTO.DataService
{
    public class SuperHeroData
    {
        private static List<SuperHero> heroes = new()
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                City = "New York City",
                DateAdded = new DateTime(2001, 08, 10),
                DateModified = null
            },
            new SuperHero
            {
                Id = 2,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                City = "Malibu",
                DateAdded = new DateTime(1970, 05, 29),
                DateModified = null
            }
        };

        private readonly IMapper _mapper;
        public SuperHeroData(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<SuperHeroDTO> GetHeroes()
        {
            // returns the data in the form of SuperHeroDTO
            List<SuperHeroDTO> heroList = heroes.Select(hero => _mapper.Map<SuperHeroDTO>(hero)).ToList();
            return heroList;
        }

        public List<SuperHeroDTO> AddHero(SuperHeroDTO newHero)
        {
            var hero = _mapper.Map<SuperHero>(newHero);
            heroes.Add(hero);

            return heroes.Select(hero => _mapper.Map<SuperHeroDTO>(hero)).ToList();
        }

        public List<SuperHero> GetHeroesFull()
        {
            return heroes;
        }
    }
}
