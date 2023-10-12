using AutoMapper;
using AutoMapperDTO.Entities;

namespace AutoMapperDTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // From SuperHero, map to SuperHeroDTO
            CreateMap<SuperHero, SuperHeroDTO>();

            // From SuperHeroDTO, map to SuperHero
            CreateMap<SuperHeroDTO, SuperHero>();
        }
    }
}
