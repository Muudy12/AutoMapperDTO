using AutoMapper;
using AutoMapperDTO.DataService;
using AutoMapperDTO.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperDTO.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroData _heroData;

        public SuperHeroController(IMapper mapper, SuperHeroData heroData)
        {
            _heroData = heroData;
        }

        /// <summary>
        /// Returns SuperHero in mapped SuperHeroDTO
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<SuperHero>> GetHeroes()
        {
            return Ok(_heroData.GetHeroes());
        }

        /// <summary>
        /// Adding new SuperHeroDTO which gets mapped to SuperHero before adding to List of SuperHero
        /// </summary>
        /// <param name="newHero"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<List<SuperHero>> AddHero(SuperHeroDTO newHero)
        {
            return Ok(_heroData.AddHero(newHero));
        }

        /// <summary>
        /// Returns List of SuperHero
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<SuperHero>> GetHeroesFull()
        {
            return Ok(_heroData.GetHeroesFull());
        }
    }
}
