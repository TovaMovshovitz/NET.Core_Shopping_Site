using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RatingRepository : IRatingRepository
    {
        MyShop213354335Context _MyShopContext;
        public RatingRepository(MyShop213354335Context myShopContext)
        {
            _MyShopContext = myShopContext;
        }
        public async Task<Rating> AddRating(Rating newRating)
        {
            await _MyShopContext.Rating.AddAsync(newRating);
            await _MyShopContext.SaveChangesAsync();
            return newRating;
        }
    }
}
