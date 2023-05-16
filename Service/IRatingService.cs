using entities;

namespace Service
{
    public interface IRatingService
    {
        Task<Rating> AddRating(Rating newRating);
    }
}