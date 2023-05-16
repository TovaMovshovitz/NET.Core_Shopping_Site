using entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RatingService : IRatingService
    {
        IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        public async Task<Rating> AddRating(Rating newRating)
        {
            return await _ratingRepository.AddRating(newRating);
        }
    }
}
