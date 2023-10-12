using AutoMapper;
using AutoMapperDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLogic
{
    public class SuperHeroService
    {
        private readonly SuperHeroData _heroData;
        private readonly IMapper _mapper;

        public SuperHeroService(SuperHeroData heroData,IMapper mapper)
        {
            _heroData = heroData;
            _mapper = mapper;
        }

    }
}
